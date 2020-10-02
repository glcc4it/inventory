using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_Inventory
{
    public class Encryption
    {
        public static string InverseByBase(string st, int MoveBase)
		{
			StringBuilder SB = new StringBuilder();
			//st = ConvertToLetterDigit(st);
			int c = 0;
			int i = 0;
			while (i < st.Length)
			{
				if (i + MoveBase > st.Length - 1)
				{
					c = st.Length - i;
				}
				else
				{
					c = MoveBase;
				}
				SB.Append(InverseString(st.Substring(i, c)));
				i += MoveBase;
			}
			return SB.ToString();
		}

		public static string InverseString(string st)
		{
			StringBuilder SB = new StringBuilder();
			for (int i = st.Length - 1; i >= 0; i--)
			{
				SB.Append(st[i]);
			}
			return SB.ToString();
		}

		public static string ConvertToLetterDigit(string st)
		{
			StringBuilder SB = new StringBuilder();
			foreach (char ch in st)
			{
				if (char.IsLetterOrDigit(ch) == false)
				{
					SB.Append(Convert.ToInt16(ch).ToString());
				}
				else
				{
					SB.Append(ch);
				}
			}
			return SB.ToString();
		}

		/// <summary>
		/// moving all characters in string insert then into new index
		/// </summary>
		/// <param name="st">string to moving characters</param>
		/// <returns>moved characters string</returns>
		public static string Boring(string st)
		{
			int NewPlace = 0;
			char ch = '\0';
//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of st.Length for every iteration:
			int tempVar = st.Length;
			for (int i = 0; i < tempVar; i++)
			{
				NewPlace = i * Convert.ToUInt16(st[i]);
				NewPlace = NewPlace % st.Length;
				ch = st[i];
				st = st.Remove(i, 1);
				st = st.Insert(NewPlace, ch.ToString());
			}
			return st;
		}

		public static string MakePassword(string st, string Identifier)
		{
			if (Identifier.Length != 3)
			{
				throw new ArgumentException("Identifier must be 3 character length");
			}

			int[] num = new int[3];
			num[0] = Convert.ToInt32(Identifier[0].ToString(), 10);
			num[1] = Convert.ToInt32(Identifier[1].ToString(), 10);
			num[2] = Convert.ToInt32(Identifier[2].ToString(), 10);
			st = Boring(st);
			st = InverseByBase(st, num[0]);
			st = InverseByBase(st, num[1]);
			st = InverseByBase(st, num[2]);

			StringBuilder SB = new StringBuilder();
			foreach (char ch in st)
			{
				SB.Append(ChangeChar(ch, num));
			}
			return SB.ToString();
		}

		private static char ChangeChar(char ch, int[] EnCode)
		{
			ch = char.ToUpper(ch);
			if (ch.CompareTo('A') >= 0 && ch.CompareTo('H') <= 0)
			{
				return Convert.ToChar(Convert.ToInt32(ch) + 2 * EnCode[0]);
			}
			else if (ch.CompareTo('I') >= 0 && ch.CompareTo('P') <= 0)
			{
				return Convert.ToChar(Convert.ToInt32(ch) - EnCode[2]);
			}
			else if (ch.CompareTo('Q') >= 0 && ch.CompareTo('Z') <= 0)
			{
				return Convert.ToChar(Convert.ToInt32(ch) - EnCode[1]);
			}
			else if (ch.CompareTo('0') >= 0 && ch.CompareTo('4') <= 0)
			{
				return Convert.ToChar(Convert.ToInt32(ch) + 5);
			}
			else if (ch.CompareTo('5') >= 0 && ch.CompareTo('9') <= 0)
			{
				return Convert.ToChar(Convert.ToInt32(ch) - 5);
			}
			else
			{
				return '0';
			}
    }
}

}
    
