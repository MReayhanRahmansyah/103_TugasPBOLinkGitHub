using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_11_Inheritance_Halaman_310
{
    public class KomisiTambahanKaryawan
    {
        public string NamaDepan;
        public string NamaBelakang;
        public string NoKTP;
        private decimal penjualanKotor; // penjualan mingguan kotor
        private decimal tingkatKomisi; // persentase komisi
        private decimal gajiPokok; // gaji pokok per minggu

        // konstruktor enam parameter
        public KomisiTambahanKaryawan(string namaDepan, string namaBelakang, string noKTP, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
        {
            // panggilan implisit ke konstruktor objek terjadi di sini
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NoKTP = noKTP;
            PenjualanKotor = penjualanKotor; // memvalidasi penjualan kotor
            TingkatKomisi = tingkatKomisi; // memvalidasi tingkat komisi
            GajiPokok = gajiPokok; // memvalidasi gaji pokok
        }
        public void setNamaDepan(string namaDepan)
        {
            NamaDepan = namaDepan;
        }
        public string getNamaDepan()
        {
            return NamaDepan;
        }
        public void setNamaBelakang(string namaBelakang)
        {
            NamaBelakang = namaBelakang;
        }
        public string getNamaBelakang()
        {
            return NamaBelakang;
        }
        public void setNoKTP(string noKTP)
        {
            NoKTP = noKTP;
        }
        public string getNoKTP()
        {
            return NoKTP;
        }
        // properti yang mendapatkan dan menetapkan komisi penjualan kotor karyawan
        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                penjualanKotor = (value < 0) ? 0 : value; // memvalidasi
            }
        }
        // properti yang mendapatkan dan menetapkan tingkat komisi komisi karyawan
        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                tingkatKomisi = (value > 0 && value < 1) ? value : 0; // memvalidasi
            }
        }
        // properti yang mendapatkan dan menetapkan KomisiTambahanKaryawan gaji pokok
        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                gajiPokok = (value < 0) ? 0 : value; // memvalidasi
            }
        }
        // menghitung komisi gaji pegawai
        public decimal Pendapatan()
        {
            return gajiPokok + (tingkatKomisi * penjualanKotor);
        }
        // mengembalikan representasi string dari objek KomisiKaryawan
        public override string ToString()
        {
            return string.Format(" \n Nama Depan : {0} \n Nama Belakang : {1} \n No KTP : {2} \n Penjualan Kotor : {3} \n Tingkat Komisi : {4} \n Gaji Pokok : {5}", NamaDepan, NamaBelakang, NoKTP, penjualanKotor, tingkatKomisi, gajiPokok);
        }
        // Menguji kelas KomisiKaryawan
        static void Main(string[] args)
        {
            // membuat instance objek KomisiKaryawan
            KomisiTambahanKaryawan karyawan = new KomisiTambahanKaryawan("Bob", "Lewis", "333-33-333", 5000.00M, .04M, 300.00M);
            // menampilkan data KomisiKaryawan
            Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode : \n");
            Console.WriteLine();
            Console.WriteLine("Nama Depan adalah {0}", karyawan.NamaDepan);
            Console.WriteLine();
            Console.WriteLine("Nama Belakang adalah {0}", karyawan.NamaBelakang);
            Console.WriteLine();
            Console.WriteLine("No KTP adalah {0}", karyawan.NoKTP);
            Console.WriteLine();
            Console.WriteLine("Penjualan Kotornya adalah {0:C}", karyawan.PenjualanKotor);
            Console.WriteLine();
            Console.WriteLine("Tingkat Komisinya adalah {0:F2}", karyawan.TingkatKomisi);
            Console.WriteLine();
            Console.WriteLine("Gaji Pokoknya adalah {0:C}", karyawan.GajiPokok);
            Console.WriteLine();
            Console.WriteLine("Pendapatanya adalah {0:C}", karyawan.Pendapatan());

            karyawan.PenjualanKotor = 5000.00M; // menetapkan penjualan kotor
            karyawan.TingkatKomisi = .04M; // menetapkan tingkat  komisi
            karyawan.GajiPokok = 1000.00M; // menetapkan gaji pokok
            Console.WriteLine("\n{0}:\n\n{1}", "Informasi karyawan yang diperbarui diperoleh dari ToString", karyawan);
            Console.WriteLine(" Dengan Pendapatan akhir : {0:C}", karyawan.Pendapatan());
            Console.ReadLine();
        }
    }
}
