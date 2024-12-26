using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Asbtract;
using BlocknotEF.Services.Concrete;

namespace BlocknotEF.Deskop
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
        }

        private async Task UpdateListBox()
        {
            this.listBox1.Items.Clear();
            using (IRecordService recordService = new RecordService())
            {
                var records = await recordService.GetRecords();

                foreach (var record in records)
                {
                    this.listBox1.Items.Add(record);
                }
            }
        }
        private async void FormMain_Load(object? sender, EventArgs e)
        {
            await UpdateListBox();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            using(IRecordService recordService = new RecordService())
            {
                string name = this.txtName.Text;
                string phone = this.txtPhone.Text;

                Record record = new Record
                {
                    Name = name,
                    PhoneNumber = phone
                };

                await recordService.CreateRecordAsync(record);
                await UpdateListBox();
            }
        }
    }
}
