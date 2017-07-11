var app = angular.module('contactApp', ['ngRoute']);

app.controller('contactsController', ['$scope', '$http', function ($scope, $http) {

    var self = this;
    var uri = 'http://localhost:64014/Contacts';
    $http.get(uri).then(function (response) { self.contacts = response.data; });
}]);


app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);
    $routeProvider.
        when('/', { controller: 'contactsController', templateUrl: 'Home/Index.html' });
});



