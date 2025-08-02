using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helpers;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Contexts;
using System.Data.Entity;

namespace WindowsFormsApp1.UserControls
{
    public partial class UC_SearchPhotoWIthAI : UserControl
    {
        private string selectedImagePath = "";
        private readonly string serpApiKey = ConfigurationManager.AppSettings["SerpApiKey"];
        private readonly string imgbbApiKey = ConfigurationManager.AppSettings["ImgbbApiKey"];

        private static readonly HttpClient _httpClient = new HttpClient();

        private Guid _currentUserId;
        private AppDbContext _dbContext;

        public UC_SearchPhotoWIthAI(Guid userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            _dbContext = new AppDbContext();

            listViewResults.View = View.Details;
            listViewResults.FullRowSelect = true;
            listViewResults.GridLines = true;

            listViewResults.Columns.Add("Başlıq", 200);
            listViewResults.Columns.Add("Link", 400);
            listViewResults.Columns.Add("Oxşar Tapıldı", 100);

            listViewResults.MouseClick += ListViewResults_MouseClick;
        }

        private void ListViewResults_MouseClick(object sender, MouseEventArgs e)
        {
            var info = listViewResults.HitTest(e.Location);

            if (info.Item != null && info.SubItem != null)
            {
                if (info.Item.SubItems.IndexOf(info.SubItem) == 1)
                {
                    var link = info.SubItem.Text;

                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = link,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Link açılarkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) // SELECT
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = dlg.FileName;
                pictureBoxSelected.ImageLocation = selectedImagePath;
                pictureBoxSelected.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private async void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                CustomMessageBox.Show("Zəhmət olmasa şəkil seçin.", "Məlumat", MessageBoxIcon.Information);
                return;
            }

            listViewResults.Items.Clear();
            ListViewItem loadingItem = new ListViewItem("Şəkil yüklənir...");
            listViewResults.Items.Add(loadingItem);

            if (System.IO.Path.GetExtension(selectedImagePath).ToLower() == ".bmp")
            {
                selectedImagePath = ConvertBmpToJpeg(selectedImagePath);
            }

            string imageUrl = await UploadImageToImgbb(selectedImagePath);

            listViewResults.Items.Clear();

            if (string.IsNullOrEmpty(imageUrl))
            {
                CustomMessageBox.Show("Şəkil yüklənərkən xəta baş verdi.", "Xəta", MessageBoxIcon.Error);
                return;
            }

            listViewResults.Items.Add(new ListViewItem(new string[] { "Şəkil yükləndi:", imageUrl, "" }));

            await CallSerpApi(imageUrl);

            await SaveSearchLogToDatabase(imageUrl, "Şəkil axtarışı");
        }

        private async Task<string> UploadImageToImgbb(string imagePath)
        {
            using (var content = new MultipartFormDataContent())
            {
                try
                {
                    byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                    var imageContent = new ByteArrayContent(imageBytes);
                    imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    content.Add(imageContent, "image", "upload.jpg");

                    string url = $"https://api.imgbb.com/1/upload?key={imgbbApiKey}";

                    var response = await _httpClient.PostAsync(url, content);
                    string json = await response.Content.ReadAsStringAsync();

                    JObject obj = JObject.Parse(json);
                    string imageUrl = obj["data"]?["url"]?.ToString();

                    return imageUrl;
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Şəkil yükləmə xətası: " + ex.Message, "Xəta", MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private async Task CallSerpApi(string imageUrl)
        {
            string url = $"https://serpapi.com/search.json?engine=google_reverse_image&image_url={Uri.EscapeDataString(imageUrl)}&api_key={serpApiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    JObject obj = JObject.Parse(json);
                    JArray results = (JArray)obj["image_results"];
                    int count = results.Count;

                    foreach (var result in results)
                    {
                        string title = result["title"]?.ToString() ?? "N/A";
                        string link = result["link"]?.ToString() ?? "N/A";

                        ListViewItem item = new ListViewItem(title);
                        item.SubItems.Add(link);
                        item.SubItems.Add(count.ToString());
                        listViewResults.Items.Add(item);
                    }

                    ListViewItem summary = new ListViewItem("Ümumi nəticə:");
                    summary.SubItems.Add("-");
                    summary.SubItems.Add(count.ToString());
                    summary.ForeColor = Color.Blue;
                    listViewResults.Items.Add(summary);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Axtarış zamanı xəta baş verdi: " + ex.Message, "Xəta", MessageBoxIcon.Error);
                }
            }
        }

        private string ConvertBmpToJpeg(string bmpPath)
        {
            string jpegPath = System.IO.Path.ChangeExtension(bmpPath, ".jpg");
            using (Bitmap bmp = new Bitmap(bmpPath))
            {
                bmp.Save(jpegPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return jpegPath;
        }

        private async Task SaveSearchLogToDatabase(string imageUrl, string queryTitle)
        {
            try
            {
                var searchLog = new SearchLog
                {
                    UserId = _currentUserId,
                    ImageUrl = imageUrl,
                    SearchQueryTitle = queryTitle,
                    SearchDate = DateTime.Now
                };
                _dbContext.SearchLogs.Add(searchLog);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Axtarış tarixçəsi verilənlər bazasına yazılanda xəta: " + ex.Message, "Xəta", MessageBoxIcon.Error);
            }
        }
    }
}