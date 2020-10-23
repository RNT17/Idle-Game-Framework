// using Xunit;

// public class HelperManagerTests
// {
//     /**
//     * TotalProductionByHelperName
//     */
//     /*
//         TotalProductionByHelperName Value should be 0 when helpers quantity = 0
//     */
//     [Fact]
//     public void TotalProductionValueWithHelpersQuantityZero()
//     {
//         var hm = new HelperManager();   
//         var expected = 0; 
//         var helperName = "testHelper";
//         var helper = new Helper(1, helperName, "", 10, 1); //default quantity is zero
//         hm.helpers.Add(helper);
        
//         var result = hm.CalculateTotalProductionByHelperName(helperName);
//         Assert.Equal(expected, result);
//     }

//     /*
//         TotalProductionByHelperName Value should be 1 when 1 helper added - (1 production value)
//     */
//     [Fact]
//     public void TotalProductionValueWithOneHelperAdded()
//     {
//         var hm = new HelperManager();   
//         var expected = 1; 
//         var helperName = "testHelper";
//         var helper = new Helper(1, helperName,"",10,1);
//         helper.quantity = 1;
//         hm.helpers.Add(helper);    

//         var result = hm.CalculateTotalProductionByHelperName(helperName);    
//         Assert.Equal(expected, result);
//     }

//     /*
//         TotalProductionByHelperName Value should be 1 when 1 helper added - (1 production value)
//     */
//     [Fact]
//     public void TotalProductionValueWithTwoHelpersAdded()
//     {
//         var hm = new HelperManager();   
//         var expected = 1; 
        
//         var helperName = "testHelper";
//         var helper = new Helper(1, helperName,"",10,1);

//         var helperName2 = "testHelper2";
//         var helper2 = new Helper(2, helperName2,"",10,1);


//         helper.quantity = 1;
//         helper2.quantity = 1;
//         hm.helpers.Add(helper);    
//         hm.helpers.Add(helper2);    

//         var result = hm.CalculateTotalProductionByHelperName(helperName);    
//         Assert.Equal(expected, result);
//     }

//     [Fact]
//     public void HasHelperWithId()
//     {
//         var helperManager = new HelperManager();
//         var helper = new Helper(1, "helper1");
//         var helper2 = new Helper(2, "helper2");

//         helperManager.helpers.Add(helper);
//         helperManager.helpers.Add(helper2);

//         var expected = true;
//         var result = helperManager.HasHelperWithId(1);

//         Assert.Equal(expected, result);
//     }

//     [Fact]
//     public void HasHelperWithIdIsFalse()
//     {
//         var helperManager = new HelperManager();
//         var helper = new Helper(1, "helper1");
//         var helper2 = new Helper(2, "helper2");

//         helperManager.helpers.Add(helper);
//         helperManager.helpers.Add(helper2);

//         var expected = false;
//         var result = helperManager.HasHelperWithId(3);

//         Assert.Equal(expected, result);
//     }

//     [Fact]
//     public void GetHelperById()
//     {
//         var hm = new HelperManager();
//         hm.InitHelpers();

//         var helper = hm.HelperById(2);
//         var expected = 2;
//         var result = helper.id;

//         Assert.Equal(expected, result);
//     }
// }