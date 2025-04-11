using System;
using System.Configuration;
using Newtonsoft.Json;

namespace taskt_new
{
    public class Config
    {
        private static Config _instance;
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }

        private Config()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                // 從配置檔讀取設定
                var appSettings = ConfigurationManager.AppSettings;
                // TODO: 讀取具體配置項
            }
            catch (Exception ex)
            {
                // TODO: 處理錯誤
                throw new ConfigurationErrorsException("無法載入配置", ex);
            }
        }
    }
}
