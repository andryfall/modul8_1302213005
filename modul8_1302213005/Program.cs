// See https://aka.ms/new-console-template for more information

using modul8_1302213005;

public class program
{
    private static void Main(string[] args)
    {
        AppConfig app = new AppConfig();

        if (app.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }

        String input = Console.ReadLine();
        int kirim = Convert.ToInt32(input);
        int total = 0;
        int fee = 0;

        if (kirim <= app.config.transfer.threshold)
        {
            fee = app.config.transfer.low_fee;
            total = kirim + fee;
        }else if (kirim > app.config.transfer.threshold)
        {
            fee = app.config.transfer.high_fee;
            total = kirim + fee;
        }

        Console.WriteLine();

        if (app.config.lang == "en")
        {
            Console.WriteLine("Transfer fee = " + fee);
            Console.WriteLine("Total amount = " + total);
        }
        else 
        {
            Console.WriteLine("Biaya transfer = " + fee);
            Console.WriteLine("Total biaya = " + total);
        }

        Console.WriteLine();

        if (app.config.lang == "en")
        {
            Console.WriteLine("Select transfer method:");
        }
        else
        {
            Console.WriteLine("Pilih metode transfer:");
        }

        for (int i = 1; i <= app.config.methods.Count; i++)
        {
            Console.WriteLine(i + " " + app.config.methods[i-1].nama);
        }

        String input2 = Console.ReadLine();

        Console.WriteLine();

        if (app.config.lang == "en")
        {
            Console.WriteLine("Please type '" + app.config.confirmation.en+ "' to confirm the transaction:");
        }
        else
        {
            Console.WriteLine("Ketik '" + app.config.confirmation.id + "' untuk mengkonfirmasi transaksi:");
        }

        String input3 = Console.ReadLine();

        Console.WriteLine() ;

        if (app.config.lang == "en")
        {
            if(input3 == app.config.confirmation.en)
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transder is cancelled");
            }
        }
        else
        {
            if (input3 == app.config.confirmation.id)
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}