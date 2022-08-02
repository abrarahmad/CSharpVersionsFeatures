namespace CSharpVersionsFeatures.Features
{
    public class CSharp8
    {

       

        /// <summary>
        /// C# 8.0 introduces the null-coalescing assignment operator ??=. You can use the ??= operator to assign the value of its right-hand operand 
        /// to its left-hand operand only if the left-hand operand evaluates to null.
        /// </summary>
        public static void NullCoalescingAssignmentOperator()
        {
            List<int>? numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
        }
    }
}
