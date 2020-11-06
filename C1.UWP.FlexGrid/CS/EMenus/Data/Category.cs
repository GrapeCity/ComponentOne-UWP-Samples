using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Windows.UI.Xaml;

namespace Grapecity.C1_EMenus
{
    /// <summary>
    /// Represents a Category group
    /// </summary>
    public class Category 
    {
        private static List<Category>  _categories = null;
        public string Name { get; set; }
        public string Text { get; set; } 
        public string ImageUri { get; set; }        
        public List<SubCategory> SubCategories { get; set; }
       
        public bool IsVisible { get; set; }  
        public static List<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = GetAll();
                }
                return _categories;
            }
        }

        internal static List<Category> GetAll()
        {
            List<Category> listToReturn = new List<Category>();
            // load the report catalog
            XDocument xdoc = new XDocument();
            using (Stream fs = File.OpenRead("Assets/EatablesInfo.xml"))
            {
                xdoc = XDocument.Load(fs);
            }

            // prepare the list of reports for the TreeView
            IEnumerable<XElement> xelems = xdoc.Descendants("Category");
            listToReturn = new List<Category>();
            foreach (XElement xelem in xelems)
            {
                Category category = new Category
                {
                    IsVisible = Convert.ToBoolean(xelem.Attribute("IsVisible").Value)
                };
                if (!category.IsVisible)
                {
                    continue;
                }
                category.Name = xelem.Attribute("Name").Value;
                category.Text = xelem.Attribute("DisplayText").Value;                
                category.ImageUri = "ms-appx:///Assets/Images/Categories/" + category.Name + "/"+ xelem.Attribute("Image").Value + ".png";
                List<SubCategory> subCategories = new List<SubCategory>();
                SubCategory subCategory = new SubCategory
                {
                    IsVisible = true,
                    CategoryName = category.Name,
                    Name = "All",
                    Text = "All",
                    Items = new List<Item>()
                };
                subCategories.Add(subCategory);
                foreach (XElement childCategory in xelem.Descendants("SubCategory"))
                {
                    subCategory = new SubCategory
                    {
                        IsVisible = Convert.ToBoolean(childCategory.Attribute("IsVisible").Value)
                    };
                    if (!subCategory.IsVisible)
                    {
                        continue;
                    }
                    subCategory.CategoryName = category.Name;
                    subCategory.Name = childCategory.Attribute("Name").Value;
                    subCategory.Text = childCategory.Attribute("DisplayText").Value;                    
                    subCategories.Add(subCategory);
                    List<Item> items = new List<Item>();
                    foreach (XElement childItem in childCategory.Descendants("Item"))
                    {
                        Item item = new Item
                        {
                            IsVisible = Convert.ToBoolean(childItem.Descendants("IsVisible").FirstOrDefault().Value)
                        };
                        if (!item.IsVisible)
                        {
                            continue;
                        }
                        item.Id = Convert.ToInt32(childItem.Descendants("Id").FirstOrDefault().Value);
                        item.SubCategoryName = subCategory.Name;
                        item.Name = childItem.Descendants("Name").FirstOrDefault().Value;
                        item.Text = childItem.Descendants("DisplayText").FirstOrDefault().Value;
                        item.Description = childItem.Descendants("Description").FirstOrDefault().Value;
                        item.Units = Convert.ToInt32(childItem.Descendants("AvailableUnit").FirstOrDefault().Value);
                        item.PrizeRegular = Convert.ToInt32(childItem.Descendants("PrizeRegular").FirstOrDefault().Value);
                        item.PrizeMedium = Convert.ToInt32(childItem.Descendants("PrizeMedium").FirstOrDefault().Value);
                        item.PrizeLarge = Convert.ToInt32(childItem.Descendants("PrizeLarge").FirstOrDefault().Value);
                        item.DiscountinPercent = Convert.ToDouble(childItem.Descendants("DscountInPercent").FirstOrDefault().Value);
                        item.Rating = Convert.ToInt32(childItem.Descendants("Rating").FirstOrDefault().Value);
                        item.IsVeg = Convert.ToBoolean(childItem.Descendants("IsVeg").FirstOrDefault().Value);
                        item.IsSpecial = Convert.ToBoolean(childItem.Descendants("IsSpecial").FirstOrDefault().Value);
                        item.ImageUri = "Assets/Images/Categories/" + category.Name + "/" + subCategory.Name + "/" + childItem.Descendants("ImageName").FirstOrDefault().Value;
                        items.Add(item);
                    }
                    subCategory.Items = items;
                }
                category.SubCategories = subCategories;
                listToReturn.Add(category);
            }
            return listToReturn;
        }

       

    }

    /// <summary>
    /// Represents a sub group of group
    /// </summary>
    public class SubCategory 
    {
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string ImageUri { get; set; }
        public List<Item> Items { get; set; }       
        public bool IsVisible { get; set; }           
    }

    /// <summary>
    /// Represents an item
    /// </summary>
    public class Item 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool _isEnabled = true;
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public double PrizeRegular { get; set; }
        public double PrizeMedium { get; set; }
        public double PrizeLarge { get; set; }
        public int Units { get; set; }
        public double DiscountinPercent { get; set; }
        public bool IsVisible { get; set; }
        public int Rating { get; set; }
        public bool IsVeg { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(this, new PropertyChangedEventArgs("IsEnabled"));
                }                
            }
        }
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
    }
    #region CartItem
    public class CartItem
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string ImgUri { get; set; }
        public double PrizePerUnit { get; set; }
        public int Quantity { get; set; }
        public object Size { get; set; }
        public string Text { get; set; }
        public double TotalPrize { get; set; }
    }
    #endregion

    #region Enums
    enum SizeEnum
    {
        Regular = 1,
        Medium = 2,
        Large = 3
    }
    #endregion

}
