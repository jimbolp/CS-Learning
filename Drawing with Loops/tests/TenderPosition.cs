using System;
using System.Collections.Generic;
using System.Text;

namespace tests
{
    class TenderPosition
    {
        public int TenderHeader { get; set; }

        /// <summary>
        /// Sets the Branch Number
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><![CDATA[Should be 0 <= value <= 99]]></exception>
        public byte BranchNumber
        {
            get
            {
                return BranchNumber;
            }
            set
            {
                if (value >= 0 && value <= 99)
                {
                    BranchNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Branch number should be between 0 and 99!");
                }
            }
        }
        /// <summary>
        /// Sets the Contract Number
        /// </summary>
        /// <exception cref="ArgumentException">Max length is 48 chars</exception>
        public string ContractNumber
        {
            get
            {
                return ContractNumber;
            }
            set
            {
                if(value.Length <= 48)
                {
                    ContractNumber = value;
                }
                else
                {
                    throw new ArgumentException("ContractNumber - Maximum length allowed is 48 characters");
                }
            }
        }
        public int TenderType
        {
            get
            {
                return TenderType;
            }
            set
            {
                if(value >= 0 && value <= 6)
                {
                    TenderType = value;
                }
            }
        }
    }
}
