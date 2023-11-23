using Microsoft.AspNetCore.Http;
using System;
using System.Data;
using System.Net.Http;
using System.Reflection;
using System.Web;

namespace Services
{
    public class MenuService : IMenuService
    {
        public _5GCalc.Models.Menu GetMenu()
        {
            _5GCalc.Models.Menu returnMenu = new _5GCalc.Models.Menu();

            List<_5GCalc.Models.MenuItem> menuList = new List<_5GCalc.Models.MenuItem>();

            List<string> menuSections = new List<string>();

            DataSet itemsSet = new DataSet(); //will hold data about all the items
            itemsSet.ReadXmlSchema(HttpContext.Current.Server.MapPath("~/data/Items.xsd")); //get the schema
            itemsSet.ReadXml(HttpContext.Current.Server.MapPath("~/data/ItemsReOrder.xml")); //get the data


            //itemsSet.ReadXmlSchema(new System.IO.FileStream("~/data/Items.xsd", System.IO.FileMode.Open)); //get the schema
            //itemsSet.ReadXml(new System.IO.FileStream("~/data/ItemsReOrder.xml", System.IO.FileMode.Open)); //get the data

            HttpClient _client = new HttpClient();

            DataTable itemsTable = itemsSet.Tables[1]; //load data into table

            DataView viewSections = new DataView(itemsTable); //will store info about the sections
            viewSections.Sort = "SectionOrder"; //sort by section sort order
            DataTable distinctSections = viewSections.ToTable(true, "Section"); //build table based on section

            foreach (DataRow dr in distinctSections.Rows) //for each section
            {
                menuSections.Add(dr["Section"].ToString());
                string sectionName = dr["Section"].ToString(); //get section name
                DataView viewMenuItems = new DataView(itemsTable); //will hold menu items under this section
                viewMenuItems.Sort = "ItemOrder"; //sort by Item Order field
                DataTable menuItems = viewMenuItems.ToTable(); //turn view into a table to manipulate
                DataRow[] theseItems = menuItems.Select("Section = '" + sectionName + "'");
                foreach (DataRow midr in theseItems)
                {
                    _5GCalc.Models.MenuItem m = new _5GCalc.Models.MenuItem(midr);
                    menuList.Add(m);
                }
            }

            returnMenu.Items = menuList;
            returnMenu.Sections = menuSections;

            return returnMenu;
        }

        public int ReturnThree()
        {
            return 3;
        }
    }
}
