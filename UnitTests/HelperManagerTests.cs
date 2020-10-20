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
//         var helper = new Helper(helperName, "", 10, 1); //default quantity is zero
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
//         var helper = new Helper(helperName,"",10,1);
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
//         var helper = new Helper(helperName,"",10,1);

//         var helperName2 = "testHelper2";
//         var helper2 = new Helper(helperName2,"",10,1);


//         helper.quantity = 1;
//         helper2.quantity = 1;
//         hm.helpers.Add(helper);    
//         hm.helpers.Add(helper2);    

//         var result = hm.CalculateTotalProductionByHelperName(helperName);    
//         Assert.Equal(expected, result);
//     }
// }