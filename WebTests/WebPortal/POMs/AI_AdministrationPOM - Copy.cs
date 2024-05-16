using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestFramework;

namespace UI_Tests
{

    public class AI_AdministrationPOM : FrameworkBase
    {


        public AI_AdministrationPOM() { }
        // System Modes selection (Operation, Administration & AI Administration)

        #region General item
        public IWebElement grd_AIAdministrationGrid => WebDriver.FindElements(By.XPath("//*[contains(@class,'TableBodyDark_bodyContainer__')]")).FirstOrDefault();
        #endregion
        public double AddRandomNumber()
        {
            // create instance of Random class
            Random rand = new Random();
            // Generate and return Random number
            return rand.NextDouble();
        }

        #region System_Modes

        public IWebElement btn_AI_Administration => WebDriver.FindElements(By.XPath("//*[@id='useCasesCategories']/div[2]/button")).FirstOrDefault();
        public IWebElement btn_External => WebDriver.FindElements(By.XPath("//*[text()='External']")).FirstOrDefault();
        public IWebElement btn_Administration => WebDriver.FindElements(By.XPath("//*[text()='Administration']")).FirstOrDefault();
        public IWebElement btn_OccupancyManagement => WebDriver.FindElements(By.XPath("//*[@id='root']/div/div[4]/div[2]/div/div/div[2]/div/div[2]/div[1]/div[1]/div[1]/img")).FirstOrDefault();

        public IWebElement btn_Start => WebDriver.FindElements(By.XPath("//*[text()='Start']")).FirstOrDefault();


        #endregion

        #region Sites & Location Management Page

        //To open Sites & Location Management Page
        public IWebElement btn_SitesAndLocationManagement => WebDriver.FindElements(By.XPath("//*[text()='Sites & Locations Management']")).FirstOrDefault();

        // to see the Sites grid
        public IWebElement grd_Sites => WebDriver.FindElements(By.XPath("(//*[contains(@class,'TableDark_tableContainer__')])[1]")).FirstOrDefault();

        // to see the Locations grid
        public IWebElement grd_Locations => WebDriver.FindElements(By.XPath("(//*[contains(@class,'TableDark_tableContainer__')])[2]")).FirstOrDefault();

        //To add a new site
        public IWebElement btn_AddNewSite => WebDriver.FindElements(By.XPath("//*[contains(@class,'SiteDark_svgIcon__')]")).FirstOrDefault();

        //To edit the first site appearin the grid
        public IWebElement btn_EditSite => WebDriver.FindElements(By.XPath("(//*[contains(@class,'TableBodyDark_svgIcon__')])[1]")).FirstOrDefault();

        //To add a new location
        public IWebElement btn_AddNewLocation => WebDriver.FindElements(By.XPath("//*[contains(@class,'LocationDark_svgIcon__')]")).FirstOrDefault();

        //To edit the first location appear in the grid
        public IWebElement btn_EditLocation => WebDriver.FindElements(By.XPath("(//*[contains(@class,'TableBodyDark_svgIcon__')])[11]")).FirstOrDefault();

        //To delete the first location appear in the grid
        public IWebElement btn_DeleteLocation => WebDriver.FindElements(By.XPath("(//*[contains(@class,'TableBodyDark_svgIcon__')])[12]")).FirstOrDefault();

        //click cancel when click on delete location
        public IWebElement btn_CancelDeleteLocation => WebDriver.FindElements(By.XPath("//button[@value='Back']")).FirstOrDefault();

        //click ok when click on delete location
        public IWebElement btn_ConfirmDeleteLocation => WebDriver.FindElements(By.XPath("//button[@value='Save']")).FirstOrDefault();

        //To search for a location
        public IWebElement btn_SearchLocation => WebDriver.FindElements(By.XPath("//*[contains(@class,'GridSearchDark_searchBar__')]")).FirstOrDefault();

        //To open the dropdown for type
        public IWebElement ddl_typeDropDown => WebDriver.FindElements(By.XPath("(//*[contains(@class,'undefined DropDownDark_DropDown__')])[1]")).FirstOrDefault();

        //Select dropdown = new Select(typeDropDown);
        //dropdown.selectByIndex(1); 
        //Choose type by numbers starting from 0

        //To open dropdown for parent
        public IWebElement ParentDropDown = WebDriver.FindElements(By.XPath("(//div[contains(@class,'undefined DropDownDark_DropDown__')])[2]")).FirstOrDefault();

        //Select dropdown = new Select(ParentDropDown);
        //dropdown.selectByIndex(1); 
        //Choose type by numbers starting from 0

        //To click on apply for filter on Location
        public IWebElement btn_Apply => WebDriver.FindElements(By.XPath("//*[text()='Apply']")).FirstOrDefault();

        #endregion

        #region Add New Site

        //To write SiteName
        public IWebElement txt_SiteName => WebDriver.FindElements(By.XPath("//*[@id='sites.nameHeader']")).FirstOrDefault();

        //To write SiteCode
        public IWebElement txt_SiteCode => WebDriver.FindElements(By.XPath("//*[@id='sites.siteCode']")).FirstOrDefault();

        //To choose SiteType from dropdown
        public IWebElement SiteTypeDropDown => WebDriver.FindElements(By.XPath("(//*[text()='Site Type'])[2]")).FirstOrDefault();

        //Select dropdown = new Select(SiteTypeDropDown);
        //dropdown.selectByIndex(1); 
        //Choose type by numbers starting from 0

        //To write SiteDescription
        public IWebElement txt_SiteDescription => WebDriver.FindElements(By.XPath("//*[@id='sites.description']")).FirstOrDefault();

        //Click on Custom to choose the map image  
        public IWebElement btn_CustomSite => WebDriver.FindElements(By.XPath("//label[contains(@class,'RadioButtonDark_radioLabel__')]")).FirstOrDefault();

        //Click on Touchpoint to choose them
        public IWebElement btn_TouchpointSite => WebDriver.FindElements(By.XPath("//button[contains(@class,'TabControlDark_locationDefineBtn__')]")).FirstOrDefault();

        //Click on Camera button to choose a camera for unassigned touchpoints
        public IWebElement btn_UnassignedTouchpointsSite => WebDriver.FindElements(By.XPath("//button[contains(@class,'AdminExpenderDark_locationTpsGridBtn__')])[2]")).FirstOrDefault();

        //Click on Camera button to choose a camera for assigned touchpoints
        public IWebElement btn_AssignedTouchpointsSite => WebDriver.FindElements(By.XPath("(//button[contains(@class,'AdminExpenderDark_locationTpsGridBtn__')])[5]")).FirstOrDefault();

        //To click on save for add or edit site
        public IWebElement btn_SaveSite => WebDriver.FindElements(By.XPath("//button[text()='Save']")).FirstOrDefault();

        //To click on cancel for add or edit site
        public IWebElement btn_CancelSite => WebDriver.FindElements(By.XPath("//button[text()='Cancel']")).FirstOrDefault();

        //To ignore cancel create site
        public IWebElement btn_IgnoreCancelCreateSite => WebDriver.FindElements(By.XPath("//button[@value='Back']")).FirstOrDefault();

        //To Confirm cancel create site
        public IWebElement btn_ConfirmCancelCreateSite => WebDriver.FindElements(By.XPath("//button[@value='Save']")).FirstOrDefault();

        #endregion

        #region Add New Location

        //To write LocationName
        public IWebElement txt_LocationName => WebDriver.FindElements(By.XPath("//*[@id='locationDetails.name']")).FirstOrDefault();

        //To write LocationDescription
        public IWebElement txt_LocationDescription => WebDriver.FindElements(By.XPath("//*[@id='locationDetails.locationDescription']")).FirstOrDefault();

        //To choose LocationType from dropdown
        public IWebElement LocationTypeDropDown => WebDriver.FindElements(By.XPath("(//button[contains(@class,'undefined DropDownDark_dropdownBtnClose__')])[1]")).FirstOrDefault();

        //Select dropdown = new Select(LocationTypeDropDown);
        //dropdown.selectByIndex(1); 
        //Choose type by numbers starting from 0

        //To choose LocationParent from dropdown
        public IWebElement LocationParentDropDown => WebDriver.FindElements(By.XPath("(//button[contains(@class,'undefined DropDownDark_dropdownBtnClose__')])[2]")).FirstOrDefault();

        //Select dropdown = new Select(LocationParent);
        //dropdown.selectByIndex(1); 
        //Choose type by numbers starting from 0

        //To add custom image map
        public IWebElement btn_CustomLocation => WebDriver.FindElements(By.XPath("//label[contains(@class,'RadioButtonDark_radioLabel__')]")).FirstOrDefault();

        //Click on touchpoint to choose them
        public IWebElement btn_TouchpointLocation => WebDriver.FindElements(By.XPath("//button[contains(@class,'TabControlDark_locationDefineBtn__')]")).FirstOrDefault();

        //Click on Camera button to choose a camera for unassigned touchpoints
        public IWebElement btn_UnassignedTouchpointsLocation => WebDriver.FindElements(By.XPath("(//button[contains(@class,'AdminExpenderDark_locationTpsGridBtn__')])[2]")).FirstOrDefault();

        //Click on Camera button to choose a camera for assigned touchpoints
        public IWebElement btn_AssignedTouchpointsLocation => WebDriver.FindElements(By.XPath("(//button[contains(@class,'AdminExpenderDark_locationTpsGridBtn__')])[5]")).FirstOrDefault();

        //To click on save for add or edit Location
        public IWebElement btn_SaveLocation => WebDriver.FindElements(By.XPath("//button[text()='Save']")).FirstOrDefault();

        //To click on cancel for add or edit Location
        public IWebElement btn_CancelLocation => WebDriver.FindElements(By.XPath("//button[text()='Cancel']")).FirstOrDefault();

        //To ignore cancel create location
        public IWebElement btn_IgnoreCancelCreateLocation => WebDriver.FindElements(By.XPath("//button[@value='Back']")).FirstOrDefault();

        //To Confirm cancel create location
        public IWebElement btn_ConfirmCancelCreateLocation => WebDriver.FindElements(By.XPath("//button[@value='Save']")).FirstOrDefault();

        #endregion

        #region Touchpoint Management
        //To open Touchpoint Management page
        public IWebElement btn_TouchpointManagement => WebDriver.FindElements(By.XPath("//div[text()='Touchpoints Management']")).FirstOrDefault();

        //To see Touchpoints Grid
        public IWebElement grd_Touchpoints => WebDriver.FindElements(By.XPath("//div[contains(@class,'TableDark_tableContainer__')]")).FirstOrDefault();

        //Searchbox
        public IWebElement txt_TPSearch => WebDriver.FindElements(By.XPath("//input[contains(@class,'GridSearchDark_searchBar__')]")).FirstOrDefault();

        //To open the dropdown for type
        public IWebElement TPTypeDropDown => WebDriver.FindElements(By.XPath("(//div[contains(@class,'undefined DropDownDark_DropDown__')])[1]")).FirstOrDefault();

        //To open the dropdown for Location
        public IWebElement TPLocationDropDown => WebDriver.FindElements(By.XPath("(//div[contains(@class,'undefined DropDownDark_DropDown__')])[2]")).FirstOrDefault();

        //To click on Apply
        //public IWebElement btn_Apply => WebDriver.FindElements(By.XPath("//*[text()='Apply']")).FirstOrDefault();

        //To edit first TP
        public IWebElement btn_EditTP => WebDriver.FindElements(By.XPath("(//*[contains(@class,'TableBodyDark_Btn__')])[1]")).FirstOrDefault();

        //To delete first TP
        public IWebElement btn_DeleteTP => WebDriver.FindElements(By.XPath("(//*[contains(@class,'TableBodyDark_Btn__')])[2]")).FirstOrDefault();

        //click ok when click on delete TP
        public IWebElement btn_ConfirmDeleteTP => WebDriver.FindElements(By.XPath("//button[@value='Save']")).FirstOrDefault();

        //click Cancel when click on delete TP
        public IWebElement btn_CancelDeleteTP => WebDriver.FindElements(By.XPath("//button[@value='Back']")).FirstOrDefault();

        /*   */

        //To add new Touchpoint
        public IWebElement btn_AddNewTouchpoint => WebDriver.FindElements(By.Name("Add New Touchpoint")).FirstOrDefault();

        //Write Touchpoint Name
        public IWebElement txt_TouchpointName => WebDriver.FindElements(By.Id("touchpoints.touchpointName")).FirstOrDefault();


        //Write Touchpoint Code
        public IWebElement txt_TouchpointCode => WebDriver.FindElements(By.Id("touchpoints.touchpointCode")).FirstOrDefault();

        //Write Touchpoint Description
        public IWebElement txt_TouchpointDescription => WebDriver.FindElements(By.Id("touchpoints.touchpointDescription")).FirstOrDefault();

        //To choose from touchpointtype
        public IWebElement TouchpointTypeDropDown => WebDriver.FindElements(By.XPath("(//button[contains(@class,'undefined DropDownDark_dropdownBtnClose__')])[1]")).FirstOrDefault();


        //To choose from touchpointlocation
        public IWebElement TouchpointLocationDropDown => WebDriver.FindElements(By.XPath("(//button[contains(@class,'undefined DropDownDark_dropdownBtnClose__')])[2]")).FirstOrDefault();


        //Upload image from ypur machine for source view
        public IWebElement btn_UploadImageSV => WebDriver.FindElements(By.XPath("(//label[contains(@class,'RadioButtonDark_LabelWithoutBackground__')])[2]")).FirstOrDefault();

        //To Draw Polygon in sourceview
        public IWebElement btn_DrawPolygonSV => WebDriver.FindElements(By.XPath("(//div[contains(@class,'CameraCalibrationDark_actionBtn__')])[1]")).FirstOrDefault();

        //Click on Source View  Image
        public IWebElement SourceViewImage = WebDriver.FindElements(By.XPath("(//*[@id='Canvas'])[1]")).FirstOrDefault();
        // (//*[contains(@class,'CameraCalibrationDark_image__')])[1]

        //Upload image in 2d map calibration
        public IWebElement btn_UploadImage2D => WebDriver.FindElements(By.XPath("(//label[contains(@class,'RadioButtonDark_LabelWithoutBackground__')])[3]")).FirstOrDefault();

        //To Draw Polygon in 2d
        public IWebElement btn_DrawPolygon2D => WebDriver.FindElements(By.XPath("(//div[contains(@class,'CameraCalibrationDark_actionBtn__')])[2]")).FirstOrDefault();

        //Draw Polygon Gis Map
        public IWebElement btn_DrawPolygonGIS => WebDriver.FindElements(By.XPath("(//div[contains(@class,'CameraCalibrationDark_actionBtn__')])[3]")).FirstOrDefault();

        //Click on Calibration View
        public IWebElement btn_CalibrationView => WebDriver.FindElements(By.XPath("//div[text()='Calibrate View']")).FirstOrDefault();

        //Click on Test Calibration
        public IWebElement btn_TestCalibration => WebDriver.FindElements(By.XPath("//div[text()='Test Calibration']")).FirstOrDefault();

        //Export Json File
        public IWebElement btn_ExportJsonFile => WebDriver.FindElements(By.XPath("//div[text()='Export to JSON File']")).FirstOrDefault();

        //To click on save for add or edit TP
        public IWebElement btn_SaveTP => WebDriver.FindElements(By.XPath("//button[text()='Save']")).FirstOrDefault();

        //To click on cancel for add or edit TP
        public IWebElement btn_CancelTP => WebDriver.FindElements(By.XPath("//button[text()='Cancel']")).FirstOrDefault();

        //Group Configuration
        //Enable Grouping
        public IWebElement tgl_EnableGrouping = WebDriver.FindElements(By.Id("camStatusBtn")).FirstOrDefault();

        //Grouping Persons No Threshold
        public IWebElement txt_GroupingPersonsNoThreshold = WebDriver.FindElements(By.XPath("(//input[contains(@class,'InputDark_searchBar__')])[5]")).FirstOrDefault();

        //Grouping Distance Threshold (m)
        public IWebElement txt_GroupingDistanceThreshold = WebDriver.FindElements(By.XPath("(//input[contains(@class,'InputDark_searchBar__')])[6]")).FirstOrDefault();

        //Grouping ROI Name
        public IWebElement txt_GroupingROIName = WebDriver.FindElements(By.XPath("(//input[contains(@class,'InputDark_searchBar__')])[7]")).FirstOrDefault();
        #endregion
    }
}
