using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace var22bd
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(List<double> information)
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double de = 0;
            const int Kd = 835;
            double Kbe = Convert.ToDouble(KbeM.Text);
            double c = 0;
            double sigmaHpSht = 0;
            double sigmaHp = 0;
            double Khb = 0;
            double Khl = 0;
            double Nhe = 0;
            double Nh0 = 0;
            double Hb = Convert.ToDouble(HbM.Text); 
            double u = Convert.ToDouble(uM.Text);
            double T = Convert.ToDouble(TM.Text);
            double tch = Convert.ToDouble(tchM.Text);
            double n = Convert.ToDouble(nM.Text);

            const int Km = 10;
            double YfSht = 0;
            double Yf = 0;
            double bm = Convert.ToDouble(bmM.Text);
            double xtao = 0;
            double psibd = 0;
            int z = Convert.ToInt32(zM.Text);
            double mnm = 0;
            double Kfb = 0;
            double sigmaFpSht = 0;
            double sigmaFp = 0;


                c = (Kbe * u)/ (2 - Kbe);
                if (Hb <= 350)
                {
                    Khb = 1;
                    if (Hb > 300)
                    {
                        sigmaHpSht = 1000;
                        sigmaFpSht = 200;
                        Nh0 = 100000000;
                    }
                    else if ((Hb > 240) & (Hb <= 300))
                    {
                        sigmaHpSht = 600;
                        sigmaFpSht = 130;
                        Nh0 = 15000000;
                    }
                    else if ((Hb > 210) & (Hb <= 240))
                    {
                        sigmaHpSht = 550;
                        sigmaFpSht = 130;
                        Nh0 = 10000000;
                    }
                    else if ((Hb > 197) & (Hb <= 210))
                    {
                        sigmaHpSht = 600;
                        sigmaFpSht = 85;
                        Nh0 = 10000000;
                    }
                    else if ((Hb > 30) & (Hb <= 197))
                    {
                        sigmaHpSht = 55;
                        sigmaFpSht = 40;
                        Nh0 = 10000000;
                    }
                    else
                    {
                        sigmaHpSht = 42;
                        sigmaFpSht = 50;
                        Nh0 = 10000000;
                    }

                }
                else
                {
                    switch (Math.Round(c, 1))
                    {
                        case 0.1: Khb = 1.08; break;
                        case 0.2: Khb = 1.08; break;
                        case 0.3: Khb = 1.18; break;
                        case 0.4: Khb = 1.18; break;
                        case 0.5: Khb = 1.29; break;
                        case 0.6: Khb = 1.29; break;
                        case 0.7: Khb = 1.4; break;
                        case 0.8: Khb = 1.4; break;
                        default: Khb = 0; break;
                    }
                    sigmaHpSht = 1100;
                    sigmaFpSht = 210;
                    Nh0 = 120000000;
                }
                Nhe = 60 * tch * n;
                Khl = Math.Sqrt(Math.Sqrt(Math.Sqrt(Nh0/Nhe)));
                sigmaHp = Khl * sigmaHpSht;
                de = Kd * Math.Pow(((T * Khb)/((1 - Kbe) * Kbe * u * Math.Pow(sigmaHp,2))), 0.3333);

                xtao = u <= 4 ? (bm <= 15 ? 0.04 : bm <= 29 ? 0.04 : bm <= 40 ? 0.12 : 0.16) :
                       u <= 6.3 ? (bm <= 15 ? 0.06 : bm <= 29 ? 0.1 : bm <= 40 ? 0.14 : 0.18) : 0;


                Yf = z <= 14 ? 3.12 : z <= 16 ? 3.15 : z <= 17 ? 3.16 : z <= 18 ? 3.17 : z <= 19 ? 3.18 : z <= 20 ? 3.19 :
                     z <= 21 ? 3.20 : z <= 22 ? 3.21 : z <= 24 ? 3.23 : z <= 25 ? 3.24 : z <= 28 ? 3.27 : z <= 30 ? 3.28 :
                     z <= 32 ? 3.29 : z <= 37 ? 3.32 : z <= 40 ? 3.33 : z <= 45 ? 3.36 : z <= 50 ? 3.38 : z <= 60 ? 3.41 :
                     z <= 80 ? 3.45 : 3.49;

                YfSht = Yf * Math.Pow(((2.2 + xtao)/xtao), 2);
                psibd = Kbe / ((2 - Kbe) * Math.Sin(bm * Math.PI / 180));

                Kfb = Hb > 350 ? (c <= 0.2 ? 1.13 : c <= 0.4 ? 1.27 : c <= 0.6 ? 1.45 : 1) : 
                                 (c <= 0.2 ? 1.07 : c <= 0.4 ? 1.15 : c <= 0.6 ? 1.23 : c <= 0.8 ? 1.33 : 1);

                sigmaFp = sigmaFpSht * Kfb;
                mnm = Km * Math.Pow((T * Kfb * YfSht / (z * z * psibd * sigmaFp)), 0.3333);
             
              
           
            cM.Text = Convert.ToString(c);
            KhbM.Text = Convert.ToString(Khb);
            NheM.Text = Convert.ToString(Nhe);
            Nh0M.Text = Convert.ToString(Nh0);
            sigmaHpShtM.Text = Convert.ToString(sigmaHpSht);
            KhlM.Text = Convert.ToString(Math.Round(Khl, 5));
            sigmaHpM.Text = Convert.ToString(Math.Round(sigmaHp,5));
            deM.Text = Convert.ToString(de);
            YfShtM.Text = Convert.ToString(Math.Round(YfSht, 5));
            YfM.Text = Convert.ToString(Yf);
            xtaoM.Text = Convert.ToString(xtao);
            psibdM.Text = Convert.ToString(Math.Round(psibd, 5));
            mnmM.Text = Convert.ToString(Math.Round(mnm, 5));
            KfbM.Text = Convert.ToString(Math.Round(Kfb, 5));
            sigmaFpShtM.Text = Convert.ToString(sigmaFpSht);
            sigmaFpM.Text = Convert.ToString(sigmaFp);


            deS.Text += "\n" + Convert.ToString(Math.Round(de, 3));
            cS.Text += "\n" + Convert.ToString(Math.Round(c, 3));
            KhbS.Text += "\n" + Convert.ToString(Math.Round(Khb, 3));
            NheS.Text += "\n" + Convert.ToString(Math.Round(Nhe, 3));
            Nh0S.Text += "\n" + (Convert.ToString(Nh0));
            sigmaHpShtS.Text += "\n" + Convert.ToString(Math.Round(sigmaHpSht, 3));
            KhlS.Text += "\n" + Convert.ToString(Math.Round(Khl, 3));
            sigmaHpS.Text += "\n" + Convert.ToString(Math.Round(sigmaHp, 3));
            YfShtS.Text += "\n" + Convert.ToString(Math.Round(YfSht, 3));
            YfS.Text += "\n" + Convert.ToString(Math.Round(Yf, 3));
            xtaoS.Text += "\n" + Convert.ToString(Math.Round(xtao, 3));
            psibdS.Text += "\n" + Convert.ToString(Math.Round(psibd, 3));
            mnmS.Text += "\n" + Convert.ToString(Math.Round(mnm, 3));
            KfbS.Text += "\n" + Convert.ToString(Math.Round(Kfb, 3));
            sigmaFpShtS.Text += "\n" + Convert.ToString(Math.Round(sigmaFpSht, 3));
            sigmaFpS.Text += "\n" + Convert.ToString(Math.Round(sigmaFp, 3));
            KbeS.Text += "\n" + Convert.ToString(Math.Round(Kbe, 3));
            HbS.Text += "\n" + Convert.ToString(Math.Round(Hb, 3));
            uS.Text += "\n" + Convert.ToString(Math.Round(u, 3));
            TS.Text += "\n" + Convert.ToString(Math.Round(T, 3));
            nS.Text += "\n" + Convert.ToString(Math.Round(n, 3));
            bmS.Text += "\n" + Convert.ToString(Math.Round(bm, 3));
            zS.Text += "\n" + Convert.ToString(z);
            tchS.Text += "\n" + Convert.ToString(Math.Round(tch, 3));

        }

        
      
    }
}
