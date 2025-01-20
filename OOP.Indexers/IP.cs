namespace OOP.Indexers
{
    /// Represents an IPv4 address with indexer access to individual octets
    public class IP
    {
        private readonly int[] _octets = new int[4];
        private const int OCTET_COUNT = 4;
        private const int MIN_OCTET_VALUE = 0;
        private const int MAX_OCTET_VALUE = 255;

        // Indexer to get or set individual octets of the IP address
        // Index of the octet (0-3)
        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _octets[index];
            }
            set
            {
                ValidateIndex(index);
                ValidateOctetValue(value);
                _octets[index] = value;
            }
        }

        // Creates an IP address from a string representation
        // IP address in format "xxx.xxx.xxx.xxx"
        public IP(string ipAddress)
        {
            string[] parts = ipAddress.Split('.');
            if (parts.Length != OCTET_COUNT)
                throw new ArgumentException("Invalid IP address format", nameof(ipAddress));

            for (int i = 0; i < parts.Length; i++)
            {
                int value = Convert.ToInt32(parts[i]);
                ValidateOctetValue(value);
                _octets[i] = value;
            }
        }

        // Creates an IP address from four individual octets
        public IP(int octet1, int octet2, int octet3, int octet4)
        {
            int[] octets = { octet1, octet2, octet3, octet4 };
            foreach (int octet in octets)
                ValidateOctetValue(octet);

            Array.Copy(octets, _octets, OCTET_COUNT);
        }

        // Gets the string representation of the IP address
        public string GetIP => string.Join('.', _octets);

        // Method to validate the index that enterd (must be between 0 and 3)
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= OCTET_COUNT)
                throw new IndexOutOfRangeException("IP address octet index must be between 0 and 3");
        }

        // Method to validate the the octet value that enterd (must be between 0 and 255)
        private void ValidateOctetValue(int value)
        {
            if (value < MIN_OCTET_VALUE || value > MAX_OCTET_VALUE)
                throw new ArgumentOutOfRangeException($"Octet value must be between {MIN_OCTET_VALUE} and {MAX_OCTET_VALUE}");
        }
    }
}