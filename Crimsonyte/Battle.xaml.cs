using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Crimsonyte
{
    /// <summary>
    /// Interakční logika pro Battle.xaml
    /// </summary>
    public partial class Battle : Window
    {
        public Battle()
        {
            InitializeComponent();
            labelPlayerName.Content = Stats.playerName;
            Stats.playerHP = 150;
            barPlayerHP.Maximum = Stats.playerHP;
            barPlayerHP.Value = Stats.playerHP;

            labelEnemyName.Content = "Guardian of the Entrance";
            Stats.enemyHP = 100;
            Stats.enemyDMGMin = 5;
            Stats.enemyDMGMax = 10;
            barEnemyHP.Maximum = Stats.enemyHP;
            barEnemyHP.Value = Stats.enemyHP;

            Stats.room = 1;
            labelRoom.Content = $"Room: {Stats.room}";
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            if(Stats.usedAttack == false)
            {
                Stats.usedAttack = true;

                Stats.value = Stats.rng.Next(25, 31);
                labelInfo.Content = $"You dealt {Stats.value} damage";
                Stats.enemyHP -= Stats.value;
                barEnemyHP.Value = Stats.enemyHP;
            }
            btnNext_Click(sender, e);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Stats.usedAttack = false;
            if (barEnemyHP.Value <= 0)
            {
                Stats.room++;
                labelRoom.Content = $"Room: {Stats.room}";
                switch (Stats.room)
                {
                    case 2:
                        labelEnemyName.Content = "Lyney";
                        enemyPic1.Visibility = Visibility.Hidden;
                        enemyPic2.Visibility = Visibility.Visible;
                        Stats.enemyHP = 125;
                        Stats.enemyDMGMin = 15;
                        Stats.enemyDMGMax = 20;
                        break;
                    case 3:
                        labelEnemyName.Content = "Arlecchino";
                        enemyPic2.Visibility = Visibility.Hidden;
                        enemyPic3.Visibility = Visibility.Visible;
                        Stats.enemyHP = 175;
                        Stats.enemyDMGMin = 20;
                        Stats.enemyDMGMax = 30;
                        break;
                    case 4:
                        MessageBox.Show("You won!");
                        //SEM DODAT OTEVŘENÍ WIN SCREENU
                        MessageBox.Show("The project is now going to self-destruct!");
                        Close();
                        break;
                }
                barEnemyHP.Maximum = Stats.enemyHP;
                barEnemyHP.Value = Stats.enemyHP;
            }
            else
            {
                Stats.value = Stats.rng.Next(Stats.enemyDMGMin, Stats.enemyDMGMax + 1);
                Stats.playerHP -= Stats.value;
                barPlayerHP.Value = Stats.playerHP;

                if(Stats.playerHP <= 0)
                {
                    MessageBox.Show("YOU DIED");
                    Window windowMenu = new MainWindow();
                    windowMenu.Show();
                    this.Close();
                }
            }
        }

        private void btnParry_Click(object sender, RoutedEventArgs e)
        {
            if (Stats.usedAttack == false)
            {
                Stats.usedAttack = true;

                Stats.value = Stats.rng.Next(0, 101);
                if(Stats.value <= 60)
                {
                    Stats.value = Stats.rng.Next(Stats.enemyDMGMin, Stats.enemyDMGMax + 1);
                    labelInfo.Content = $"You failed the parry and took {Stats.value} damage";
                    Stats.playerHP -= Stats.value;
                    barPlayerHP.Value = Stats.playerHP;
                }
                else
                {
                    Stats.value = Stats.rng.Next(40, 51);
                    labelInfo.Content = $"You succesfully paried and dealt {Stats.value} damage";
                    Stats.enemyHP -= Stats.value;
                    barEnemyHP.Value = Stats.enemyHP;
                }
            }
            btnNext_Click(sender, e);
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            if (Stats.usedAttack == false)
            {
                Stats.usedAttack = true;

                Stats.value = Stats.rng.Next(30, 51);
                labelInfo.Content = $"You healed for {Stats.value} HP";
                Stats.playerHP += Stats.value;
                barPlayerHP.Value = Stats.playerHP;
            }
            btnNext_Click(sender, e);
        }
    }
}
