using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class frmCadLivros : Form
    {
        private List<Book> books = new List<Book>();
        private readonly HttpClient client = new HttpClient();

        public frmCadLivros()
        {
            InitializeComponent();
            LoadBooks();
        }

        private async void LoadBooks()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response =
                        await client.GetAsync("http://localhost:3000/books");
                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    books = JsonSerializer.Deserialize<List<Book>>(json);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = books;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show("Erro ao carregar livros: " + e.Message);
                }
            }
        }

      

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var book = new Book
            {
                title = txtTitulo.Text,
                author = txtAutor.Text,
                isbn = txtISBN.Text

            };

            var json = JsonSerializer.Serialize(book);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://localhost:3000/books", content);
                response.EnsureSuccessStatusCode();
                LoadBooks();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Erro ao adicionar livro: " + ex.Message);
            }


        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
       
    }
}
