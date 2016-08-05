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
      // console.log($location.path('/'));
       var viewBase = '/Areas/POS/Views/';
      $routeProvider.
        when('/EmployeeList', {
            templateUrl: viewBase + 'Admin/EmployeeList.cshtml',
        }).
        when('/showOrders', {
            templateUrl: 'templates/show-orders.html',
            controller: 'ShowOrdersController'
        }).
        otherwise({
            redirectTo: '/'
        });
       // Specify HTML5 mode (using the History APIs) or HashBang syntax.
      $locationProvider.html5Mode(false).hashPrefix('!');

      //$locationProvider.html5Mode(true);
  }]);

})();