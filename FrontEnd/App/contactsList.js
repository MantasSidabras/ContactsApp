var app = angular.module('contactApp', ['ngRoute']);

app.controller('contactsController', ['$scope', '$http', function ($scope, $http) {

    var self = this;
    var uri = 'http://localhost:64014/Contacts';
    $http.get(uri).then(function (response) { self.contacts = response.data; });

    var uriDelete = 'http://localhost:64014/Contacts/Delete';
    $scope.remove = function (contact) {
        $http.delete(uriDelete + '/' + contact.Id).then(function (response) {
            var index = self.contacts.indexOf(contact);
            self.contacts.splice(index, 1);
        });
    };
}]);

app.controller('contactCreateController', function ($scope, $http, $location) {
    $scope.contact = {};

    var self = this;
    var uriCreate = 'http://localhost:64014/Contacts/Create';

    $scope.create = function () {
        $http.post(uriCreate, $scope.contact).then(
            function (response) {
                $location.path("/");
            });
    };
});

app.controller('contactEditController', function ($http, $routeParams, $location) {
    var self = this;
    $http({
        method: 'GET',
        url: 'http://localhost:64014/Contacts/Update',
        params: { id: $routeParams.id }

    }).then(function (response) {
        self.contact = response.data;
    });

    self.edit = function () {
        $http({
            method: 'PUT',
            url: 'http://localhost:64014/Contacts/Update',
            params: { id: $routeParams.id },
            data: self.contact

        }).then(function (response) {
            $location.path("/");
        });
    };
});


//app.controller('messageController', function ($scope, $http) {
//    $scope.contact = {};

//    var self = this;
//    var uriCreate = 'http://localhost:64014/Contacts/Create';

//    $scope.create = function () {
//        $http.post(uriCreate, $scope.contact);
//    };
//});


app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/', { controller: 'contactsController', templateUrl: '/App/Templates/List.html' })
        .when('/create', { controller: 'contactCreateController', templateUrl: '/App/Templates/Create.html' })
        .when('/edit/:id', { controller: 'contactEditController', templateUrl: '/App/Templates/Edit.html' })
        .when('/message', { controller: 'contactsController', templateUrl: '/App/Templates/Message.html'});
});




