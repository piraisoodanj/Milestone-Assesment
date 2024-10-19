
namespace Part2CrestionAndModifyingPDF
{
    class DataRecord
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public DataRecord(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
