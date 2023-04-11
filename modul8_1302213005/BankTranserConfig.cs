using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302213005
{
    public class AppConfig
    {
        public BankTranserConfig config;

        private const string filelocation = "C:\\Users\\andry\\Documents\\GitHub\\modul8_1302213005\\";
        private const string filepath = filelocation + "bank_transfer_config.json";

        public AppConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                setDefault();
                WriteNewConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            string hasilBaca = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<BankTranserConfig>(hasilBaca);
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, jsonString);
        }

        private void setDefault()
        {
            Transfer transfer = new Transfer(25000000, 6500, 15000);
            Confirmation confirmation = new Confirmation("yes", "ya");
            
            List<Method> methods = new List<Method>();
            Method method;

            method = new Method("RTO (real-time)");
            methods.Add(method);

            method = new Method("SKN)");
            methods.Add(method);

            method = new Method("RTGS)");
            methods.Add(method);

            method = new Method("BI FAST");
            methods.Add(method);

            config = new BankTranserConfig("en", transfer, methods, confirmation);

        }
    }
    public class BankTranserConfig
    {
        public String lang { get; set; }
        public Transfer transfer { get; set; }
        public List<Method> methods { get; set; }
        public Confirmation confirmation { get; set; }

        public BankTranserConfig()
        {

        }

        public BankTranserConfig(string lang, Transfer transfer, List<Method> methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public Transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class Method
    {
        public String nama { get; set; }

        public Method(string nama)
        {
            this.nama = nama;
        }
    }

    public class Confirmation
    {
        public String en { get; set; }
        public String id { get; set; }

        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
}
