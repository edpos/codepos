(function () {
    'use strict';

    angular
        .module('app')
        .controller('Testcontroller', Testcontroller);

    Testcontroller.$inject = ['$location']; 

    function Testcontroller($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Testcontroller';

        activate();

        function activate() { }
    }
})();
