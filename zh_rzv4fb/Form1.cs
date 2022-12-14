namespace zh_rzv4fb
{
    public partial class Form1 : Form
    {
        Models.StudiesContext studiesContext = new Models.StudiesContext();
        public Form1()
        {
            InitializeComponent();
            Tanárszûrés();
            Szobaszûrés();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            if (add.ShowDialog() == DialogResult.OK)
            {
                Models.Course course = new Models.Course();
                course.Name = add.textBox1.Text;
                course.Code = add.textBox2.Text;

                studiesContext.Courses.Add(course);

                try
                {
                    studiesContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Datagrid datagrid = new Datagrid();
            if (datagrid.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Biztosan ki akar lépni?") == DialogResult.OK)
            {
                Close();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Szobaszûrés();
        }

        private void Szobaszûrés()
        {
            var room = from x in studiesContext.Rooms
                       where x.Name.Contains(textBox1.Text)
                       select x;

            listBox1.DataSource = room.ToList();
            listBox1.DisplayMember = "Name";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Tanárszûrés();
        }

        private void Tanárszûrés()
        {
            var instructor = from x in studiesContext.Instructors
                             where x.Name.Contains(textBox2.Text)
                             select x;

            listBox2.DataSource = instructor.ToList();
            listBox2.DisplayMember = "Name";
        }
    }
    
}