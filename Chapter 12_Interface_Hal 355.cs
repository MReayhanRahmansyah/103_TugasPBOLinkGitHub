using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_12_Interface_Hal_355
{
    public interface IPayable
    {
        decimal JumlahPembayaran();
    }
    public class Faktur : IPayable
    {
        private string NomorBagian;
        private string DeskripsiBagian;
        private int Kuantitas;
        private decimal HargaPeritem;

        public Faktur(string nomorBagian, string deskripsiBagian, int menghitung, decimal harga)
        {
            NomorBagian = nomorBagian;
            DeskripsiBagian = deskripsiBagian;
            Kuantitas = menghitung;
            HargaPeritem = harga;
        }
        public string nomorBagian
        {
            get
            {
                return nomorBagian;
            }
            set
            {
                NomorBagian = value;
            }
        }
        public string deskripsiBagian
        {
            get
            {
                return deskripsiBagian;
            }
            set
            {
                DeskripsiBagian = value;
            }
        }
        public int kuantitas
        {
            get
            {
                return kuantitas;
            }
            set
            {
                Kuantitas = (value < 0) ? 0 : value;
            }
        }
        public decimal hargaPeritem
        {
            get
            {
                return hargaPeritem;
            }
            set
            {
                HargaPeritem = (value < 0) ? 0 : value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}: \n{1}: {2} ({3}) \n{4}: {5} \n{6}: {7:C}", "Faktur", "Nomor Bagian", NomorBagian, DeskripsiBagian, "kuantitas", Kuantitas, "Harga per Item", HargaPeritem);
        }
        public decimal JumlahPembayaran()
        {
            return Kuantitas * HargaPeritem;
        }
    }
    public abstract class Karyawan : IPayable
    {
        private string NamaDepan;
        private string NamaBelakang;
        private string NoKTP;
        public Karyawan(string namaDepan, string namaBelakang, string noKTP)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NoKTP = noKTP;
        }
        public string namaDepan
        {
            get
            {
                return NamaDepan;
            }
        }
        public string namaBelakang
        {
            get
            {
                return NamaBelakang;
            }
        }
        public string noKTP
        {
            get
            {
                return NoKTP;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}\nNo KTP : {2}", NamaDepan, NamaBelakang, NoKTP);
        }
        public abstract decimal JumlahPembayaran();
    }
    public class GajiKaryawan : Karyawan
    {
        private decimal GajiMingguan;

        public GajiKaryawan(string namaDepan, string namaBelakang, string noKTP, decimal gaji)
            : base(namaDepan, namaBelakang, noKTP)
        {
            GajiMingguan = gaji;
        }
        public decimal gajiMingguan
        {
            get
            {
                return gajiMingguan;
            }
            set
            {
                GajiMingguan = ((value >= 0) ? value : 0);
            }
        }
        public override decimal JumlahPembayaran()
        {
            return GajiMingguan;
        }
        public override string ToString()
        {
            Console.WriteLine("Karyawan:");
            return string.Format("Gaji karyawan : {0}\n{1}: {2:C}", base.ToString(), "Gaji mingguan", GajiMingguan);
        }
    }
    public class PayableInterfaceTest
    {
        static void Main(string[] args)
        {
            IPayable[] payableObjects = new IPayable[4];

            payableObjects[0] = new Faktur("01234", "seat", 2, 375.00M);
            payableObjects[1] = new Faktur("56789", "tire", 4, 79.95M);
            payableObjects[2] = new GajiKaryawan("John", "Smith", "111-11-1111", 800.00M);
            payableObjects[3] = new GajiKaryawan("Lisa", "Barnes", "888-88-8888", 1200.00M);

            Console.WriteLine("Faktur dan Karyawan Proses menggunakan Polymorphisme");

            foreach (IPayable currentPayable in payableObjects)
            {
                Console.WriteLine("{0} \n{1}: {2:C}\n", currentPayable, "Tanggal jatuh tempo", currentPayable.JumlahPembayaran());
            }
            Console.ReadLine();
        }
    }
}
