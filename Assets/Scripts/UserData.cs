using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserData  {

    // Database ID
    public string id = "<<ID>>";
    // Plaintext name
    public string name = "<<USER NAME>>";
    public List<CategoryEntry> categorys = new List<CategoryEntry>();
    public UserData() { }

    public void AddCategory(string categoryName, string categoryId,string link)
    {
        AddCategoryHelper(categoryName, categoryId, link,categorys);
    }

    public void DeleteCategory(string id)
    {
        List<CategoryEntry> toDelete = categorys.FindAll(value =>
        {
            return value.categoryId == id;
        });

        foreach (CategoryEntry entry in toDelete)
        {
            categorys.Remove(entry);
        }

        foreach (CategoryEntry categoryEntry in categorys)
        {
            if (categoryEntry.categoryId == id)
                throw new System.Exception("category already exists");
        }
    }
    // Associates an existing map with a user profile.  (Usually used
    // when a new map is created.)
    private void AddCategoryHelper(string categoryName, string categoryId, string link,List<CategoryEntry> categoryList)
    {
        // Remove the map if we're saving over something that exists:
        List<CategoryEntry> toDelete = categoryList.FindAll(value =>
        {
            return value.categoryId == categoryId;
        });

        foreach (CategoryEntry entry in toDelete)
        {
            categoryList.Remove(entry);
        }

        foreach (CategoryEntry categoryEntry in categoryList)
        {
            if (categoryEntry.categoryId == categoryId)
                throw new System.Exception("category already exists");
        }

        categoryList.Add(new CategoryEntry(categoryName, categoryId,link));
    }
    [System.Serializable]
    public class CategoryEntry
    {

        //  Constructor
        public CategoryEntry(string name, string categoryId,string link)
        {
            this.name = name;
            this.categoryId = categoryId;
            this.linkImage = link;
        }

        // Unique database identifier.
        public string categoryId;
        // Plaintext string name.
        public string name = StringConstants.DefaultCategoryName;
        public string linkImage;
    }
}
