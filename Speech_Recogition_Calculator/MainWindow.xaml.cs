using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Timers;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace Speech_Recogition_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte counter = 0;
        Random ran = new Random();
        SpeechRecognitionEngine recognize = new SpeechRecognitionEngine();
        SpeechSynthesizer syn = new SpeechSynthesizer();
        SpeechRecognitionEngine listen = new SpeechRecognitionEngine();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            recognize.SetInputToDefaultAudioDevice();
            recognize.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commands.txt")))));
            recognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default);
            recognize.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(RecognizeSD);
            recognize.RecognizeAsync(RecognizeMode.Multiple);

            listen.SetInputToDefaultAudioDevice();
            listen.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commands.txt")))));
            listen.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(ListenSR);

        }

        private void Default(object sender, SpeechRecognizedEventArgs e)
        {
            int randomNum;
            string speech = e.Result.Text;

            if(speech == "Calculator")
            {
                syn.SpeakAsync("Yes? what now?");
            }
        }
        private void RecognizeSD(object sender, SpeechDetectedEventArgs e)
        {
            counter = 0;
            Timer();
        }
        private void ListenSR(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if(speech == "Hey")
            {
                listen.RecognizeAsyncCancel();
                syn.SpeakAsync("Yo");
                recognize.RecognizeAsync(RecognizeMode.Multiple);
            }
        }
        private void Timer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            if(counter == 10)
            {
                recognize.RecognizeAsyncCancel();
            }
            else if (counter == 11)
            {
                aTimer.Enabled = false;
                listen.RecognizeAsync(RecognizeMode.Multiple);
                counter = 0;
            }
        }
    }
}
