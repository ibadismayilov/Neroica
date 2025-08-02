using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Contexts;

namespace WindowsFormsApp1.UserControls
{
    public partial class UC_SearchLog : UserControl
    {
        private Guid _currentUserId;
        private AppDbContext _dbContext; 

        public UC_SearchLog(Guid userId) 
        {
            InitializeComponent();
            _currentUserId = userId;
            _dbContext = new AppDbContext(); 

            InitializeListView();
            LoadAndDisplaySearchLogs();
        }

        private void InitializeListView()
        {
            listViewSearchLogs.View = View.Details;
            listViewSearchLogs.FullRowSelect = true;
            listViewSearchLogs.GridLines = true;
            listViewSearchLogs.Dock = DockStyle.Fill;

            listViewSearchLogs.Columns.Add("Başlıq", 200);
            listViewSearchLogs.Columns.Add("Şəkil URL", 400);
            listViewSearchLogs.Columns.Add("Tarix", 150);

            listViewSearchLogs.MouseClick += ListViewSearchLogs_MouseClick;
        }

        private async void LoadAndDisplaySearchLogs()
        {
            listViewSearchLogs.Items.Clear();
            try
            {
                var logs = await _dbContext.SearchLogs.Where(sl => sl.UserId == _currentUserId).OrderByDescending(sl => sl.SearchDate).ToListAsync();

                if (!logs.Any())
                {
                    ListViewItem noResults = new ListViewItem("Heç bir axtarış tarixçəsi tapılmadı.");
                    noResults.ForeColor = System.Drawing.Color.Gray;
                    listViewSearchLogs.Items.Add(noResults);
                    return;
                }

                foreach (var log in logs)
                {
                    ListViewItem item = new ListViewItem(log.SearchQueryTitle);
                    item.SubItems.Add(log.ImageUrl);
                    item.SubItems.Add(log.SearchDate.ToString("dd.MM.yyyy HH:mm"));
                    listViewSearchLogs.Items.Add(item);
                }

                listViewSearchLogs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewSearchLogs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Axtarış tarixçəsi yüklənərkən xəta: " + ex.Message, "Xəta", MessageBoxIcon.Error);
            }
        }

        private void ListViewSearchLogs_MouseClick(object sender, MouseEventArgs e)
        {
            var info = listViewSearchLogs.HitTest(e.Location);
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
    }
}
