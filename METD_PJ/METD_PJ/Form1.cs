using BK_Functions.Database;
using CefSharp;
using CefSharp.DevTools.Browser;
using CefSharp.ModelBinding;
using CefSharp.WinForms;

namespace METD_PJ
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser? chromeBrowser;
        DbCreate create;
        public Form1()
        {
            create = new DbCreate();
            InitializeComponent();
        }

        private void Initialze()
        {
            var cefConf = new CefSettings();
            Cef.Initialize(cefConf);

            var options = new BindingOptions()
            {
                Binder = BindingOptions.DefaultBinder.Binder,
            };

            string htmlFilePath = System.IO.Path.Combine(Application.StartupPath, "html-resources", "pages", "disciplines.html");
            chromeBrowser = new ChromiumWebBrowser(htmlFilePath);

            chromeBrowser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            chromeBrowser.JavascriptObjectRepository.Register("cefCustom", new GetterObj(chromeBrowser), options);

            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            create.ExecuteDB();
            Initialze();
        }


        // Liberando os recursos ao fechar o aplicativo
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            chromeBrowser?.Dispose();
            Cef.Shutdown();
            base.OnFormClosing(e);
        }


    }
}
