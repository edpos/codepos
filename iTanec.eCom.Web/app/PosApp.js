/// <reference path="F:\Per\Projects\Pos\iTanec.eCom.Web\Areas/POS/Views/Admin/EmployeeList.cshtml" />
/// <reference path="F:\Per\Projects\Pos\iTanec.eCom.Web\Areas/POS/Views/Admin/EmployeeList.cshtml" />
var myPosApp;
(function () {
    'use strict';

   myPosApp = angular.module('PosApp', [
        // Angular modules 
        'ngRoute'
        // Custom modules 

        // 3rd Party Modules

   ]);

   myPosApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
       debugger;
      // var baseSiteUrlPath = $("base").first().attr("href");
      ////var basePath = $location.path('/');
       var viewBase = '/Areas/POS/Views/';
      $routeProvider.
        when('/POS/Admin/EmployeeList', {
            templateUrl: '/POS/Admin//EmployeeList',
        }).
        when('/Sales/CustomerList', {
            templateUrl: 'Sales/CustomerList',
        }).
        otherwise({
            redirectTo: '/'
        });
        //Specify HTML5 mode (using the History APIs) or HashBang syntax.

      $locationProvider.html5Mode(true);


  }]);

})();