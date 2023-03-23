namespace geradorcpfnote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(Generator()));
        }
        public static string Generator()
        {
            string CPF;
            Random random = new Random();
            Random Region = new Random();
            int[] NumbersCopy = new int[9];
            int[] numbers = new int[9]; //Cria um array de inteiros / Create array of ints
            for(int i = 0; i < 8; i++)
            {
                numbers[i] = random.Next(0,9);
            }

            numbers.CopyTo(NumbersCopy, 0);


            for (int i = 10; i > 1; i--) //Os loops que multiplicam o primeiro digito por 10, o segundo por 9 etc / The following loops multiply the 1st digit by 10, 2nd by 9 etc
            {
                for (int j = 0; j < 9; j++)
                {
                    numbers[j] *= i;
                }
            }


            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            sum = sum % 11; //apos somar todos os digitos do array numbers, divide-se o resultado por 11 para encontrar o resto / After adding all digits of the numbers array, the result is divided by 11 in order to find the remain


            int FirstVerifier; //esta parte e trivial e nao precisa ser explicada / this part is trivial and does not need explaining
            if (sum == 0 || sum == 1) { FirstVerifier = 0; }
            else { FirstVerifier = 11 - sum; }
            Array.Resize(ref NumbersCopy, NumbersCopy.Length + 1);//adicionar FirstVerifier ao array / adding the firstverifier to the array
            NumbersCopy[NumbersCopy.Length - 1] = FirstVerifier;

            Array.Resize(ref numbers, numbers.Length + 1);
            NumbersCopy.CopyTo(numbers, 0);

            for (int i = 10; i > 1; i--) //Os loops que seguem multiplicam o segundo digito por 10, o terceiro por 9 etc / The following loops multiply the 1st digit by 10, 2nd by 9 etc
            {
                for (int j = 1; j < 9; j++)
                {
                    numbers[j] *= i;
                }
            }


            sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            sum = sum % 11;


            int SecondVerifier;
            if (sum == 0 || sum == 1) { SecondVerifier = 0; }
            else { SecondVerifier = 11 - sum; }
            Array.Resize(ref NumbersCopy, NumbersCopy.Length + 1);//adicionar SecondVerifier ao array / adding the firstverifier to the array
            NumbersCopy[NumbersCopy.Length - 1] = SecondVerifier;


            CPF = string.Join("", NumbersCopy);
            return CPF;

        }
    }
}