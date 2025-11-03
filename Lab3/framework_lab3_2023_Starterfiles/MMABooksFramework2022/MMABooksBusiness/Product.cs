using MMABooksTools;
using System;
using System.Collections.Generic;
using System.Text;
using MMABooksProps;
using MMABooksDB;

namespace MMABooksBusiness
{
    public class Product : BaseBusiness
    {
        public int ProductID
        {
            get
            {
                return ((ProductProps)mProps).ProductID;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).ProductID))
                {
                    // no specific rules for ProductID since it's the primary key
                    ((ProductProps)mProps).ProductID = value;
                    mIsDirty = true;
                }
            }
        }
        public string ProductCode
        {
            get
            {
                return ((ProductProps)mProps).ProductCode;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).ProductCode))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 10)
                    {
                        mRules.RuleBroken("ProductCode", false);
                        ((ProductProps)mProps).ProductCode = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("ProductCode must be between 1 and 10 characters long.");
                    }
                }
            }
        }
        public string Description
        {
            get
            {
                return ((ProductProps)mProps).Description;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).Description))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 50)
                    {
                        mRules.RuleBroken("Description", false);
                        ((ProductProps)mProps).Description = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Description must be between 1 and 50 characters long.");
                    }
                }
            }
        }
        public decimal UnitPrice
        {
            get
            {
                return ((ProductProps)mProps).UnitPrice;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).UnitPrice))
                {
                    if (value >= 0)
                    {
                        mRules.RuleBroken("UnitPrice", false);
                        ((ProductProps)mProps).UnitPrice = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("UnitPrice must be a positive value.");
                    }
                }
            }
        }
        public int OnHandQuantity
        {
            get
            {
                return ((ProductProps)mProps).OnHandQuantity;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).OnHandQuantity))
                {
                    if (value >= 0)
                    {
                        mRules.RuleBroken("OnHandQuantity", false);
                        ((ProductProps)mProps).OnHandQuantity = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("OnHandQuantity must be a positive value.");
                    }
                }
            }
        }
        public override object GetList()
        {
            List<Product> products = new List<Product>();
            List<ProductProps> props = new List<ProductProps>();

            props = (List<ProductProps>)new ProductDB().RetrieveAll();
            foreach (ProductProps prop in props)
            {
                Product p = new Product(prop);
                products.Add(p);
            }

            return products;
        }

        protected override void SetDefaultProperties()
        {
        }

        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("ProductCode", true);
            mRules.RuleBroken("Description", true);
            mRules.RuleBroken("UnitPrice", true);
            mRules.RuleBroken("OnHandQuantity", true);
        }

        protected override void SetUp()
        {
            mProps = new ProductProps();
            mOldProps = new ProductProps();

            mdbReadable = new ProductDB();
            mdbWriteable = new ProductDB();

        }

        // Constructors
        public Product() : base()
        {
        }

        public Product(int key) : base(key)
        {
        }

        public Product(ProductProps prop) : base(prop)
        {
        }

    }
}
