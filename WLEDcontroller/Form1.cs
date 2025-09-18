using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;


namespace WLEDcontroller
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void save1_Click(object sender, EventArgs e)
        {
            int r = 0;
            int.TryParse(red.Text, out r);
            int g = 0;
            int.TryParse(green.Text, out g);
            int b = 0;
            int.TryParse(blue.Text, out b);
            int w = 0;
            int.TryParse(white.Text, out w);

            col1.Text = $"h{w:X2}{r:X2}{g:X2}{b:X2}";
        }

        private void save2_Click(object sender, EventArgs e)
        {
            int r = 0;
            int.TryParse(red.Text, out r);
            int g = 0;
            int.TryParse(green.Text, out g);
            int b = 0;
            int.TryParse(blue.Text, out b);
            int w = 0;
            int.TryParse(white.Text, out w);

            col2.Text = $"h{w:X2}{r:X2}{g:X2}{b:X2}";
        }

        private void save3_Click(object sender, EventArgs e)
        {
            int r = 0;
            int.TryParse(red.Text, out r);
            int g = 0;
            int.TryParse(green.Text, out g);
            int b = 0;
            int.TryParse(blue.Text, out b);
            int w = 0;
            int.TryParse(white.Text, out w);

            col3.Text = $"h{w:X2}{r:X2}{g:X2}{b:X2}";
        }

        private void toggle_Click(object sender, EventArgs e)
        {
            string a = address.Text;
            httptoggle(a);
        }

        public async Task<string> httptoggle(string address)
        {
            var start = DateTime.UtcNow;

            string url = $"http://{address}/win&T=2";
            console.Items.Add($"[REQUEST]: GET {url}");

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                var elapsed = DateTime.UtcNow - start;

                if (!response.IsSuccessStatusCode)
                {
                    console.Items.Add($"[WARN]: Non-success status {(int)response.StatusCode} {response.ReasonPhrase} after {elapsed.TotalMilliseconds}ms");
                    return null;
                }

                string responseBody = await response.Content.ReadAsStringAsync();

                console.Items.Add($"[DEBUG]: Success {(int)response.StatusCode} {response.ReasonPhrase} in {elapsed.TotalMilliseconds}ms");
                console.Items.Add($"[DEBUG]: Response length: {responseBody.Length}");
                console.Items.Add($"[DEBUG]: Response preview: {responseBody.Substring(0, Math.Min(200, responseBody.Length))}");

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                var elapsed = DateTime.UtcNow - start;
                console.Items.Add($"[ERROR]: Request error after {elapsed.TotalMilliseconds}ms: {e.Message}");
                if (e.InnerException != null)
                    console.Items.Add($"[ERROR]: Inner exception: {e.InnerException.Message}");
                return null;
            }
            catch (TaskCanceledException e)
            {
                var elapsed = DateTime.UtcNow - start;
                console.Items.Add($"[ERROR]: Request timed out after {elapsed.TotalMilliseconds}ms: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                var elapsed = DateTime.UtcNow - start;
                console.Items.Add($"[ERROR]: Unexpected exception after {elapsed.TotalMilliseconds}ms: {e.Message}");
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = address.Text;
            string cl = col1.Text;
            string c2 = col2.Text;
            string c3 = col3.Text;
            string fx = effect.Text;
            string b = bright.Text;

            httpsend(a, cl, c2, c3, fx, b);
        }

        public async Task<string> httpsend(string ip, string cl, string c2, string c3, string fx, string bright)
        {
            var start = DateTime.UtcNow;

            string url = $"http://{ip}/win&A={bright}&CL={cl}&C2={c2}&C3={c3}&FX={fx}";
            console.Items.Add($"[REQUEST]: GET {url}");

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                var elapsed = DateTime.UtcNow - start;

                if (!response.IsSuccessStatusCode)
                {
                    console.Items.Add($"[WARN]: Non-success status {(int)response.StatusCode} {response.ReasonPhrase} after {elapsed.TotalMilliseconds}ms");
                    return null;
                }

                string responseBody = await response.Content.ReadAsStringAsync();

                console.Items.Add($"[DEBUG]: Success {(int)response.StatusCode} {response.ReasonPhrase} in {elapsed.TotalMilliseconds}ms");
                console.Items.Add($"[DEBUG]: Response length: {responseBody.Length}");
                console.Items.Add($"[DEBUG]: Response preview: {responseBody.Substring(0, Math.Min(200, responseBody.Length))}");

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                var elapsed = DateTime.UtcNow - start;
                console.Items.Add($"[ERROR]: Request error after {elapsed.TotalMilliseconds}ms: {e.Message}");
                if (e.InnerException != null)
                    console.Items.Add($"[ERROR]: Inner exception: {e.InnerException.Message}");
                return null;
            }
            catch (TaskCanceledException e)
            {
                var elapsed = DateTime.UtcNow - start;
                console.Items.Add($"[ERROR]: Request timed out after {elapsed.TotalMilliseconds}ms: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                var elapsed = DateTime.UtcNow - start;
                console.Items.Add($"[ERROR]: Unexpected exception after {elapsed.TotalMilliseconds}ms: {e.Message}");
                return null;
            }
        
    } } }



    

