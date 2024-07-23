namespace StoreManager.Extensions
{
    public static class StringHelper
    {
        public static string Pluralize(this string word)
        {
            Dictionary<string, string> irregularPlurals = new()
            {
                {"ProductQuantity", "ProductsQuantity"},
                {"SupplierEmloyeeAssignmentHistory", "SuppliersEmloyeeAssignmentHistory"},
                {"SupplierTransactionDetails", "SuppliersTransactionDetails"},
                {"SupplierTransactions", "SuppliersTransactions"},
            };

            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Word cannot be null or empty");
            }

            if (irregularPlurals.ContainsKey(word.ToLower()))
            {
                // Check if the word has an irregular plural form
                return irregularPlurals[word.ToLower()];
            }
            if (word.EndsWith("y"))
            {
                // Rule for words ending in 'y'
                return word.Substring(0, word.Length - 1) + "ies";
            }
            if (word.EndsWith("s") || word.EndsWith("x") || word.EndsWith("z") || word.EndsWith("ch") || word.EndsWith("sh"))
            {
                // Rule for words ending in 's', 'x', 'z', 'ch', or 'sh'
                return word + "es";
            }

            // Default rule for adding 's'
            return word + "s";
        }
    }
}
