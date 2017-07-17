﻿var app = angular.module('contactApp', ['ngRoute']);

app.controller('contactsController', ['$scope', '$http', function ($scope, $http, $location) {

    var self = this;
    var uri = 'http://localhost:64014/Contacts';
    $http.get(uri).then(function (response) { self.contacts = response.data; });

    var uriDelete = 'http://localhost:64014/Contacts/Delete';
    self.remove = function (contact) {
        $http.delete(uriDelete + '/' + contact.Id).then(function (response) {
            var index = self.contacts.indexOf(contact);
            self.contacts.splice(index, 1);
        }).then(function () {
            $location.path("/");
        });

        $http({
            method: 'DELETE',


        });
    };
}]);

app.controller('contactCreateController', function ($scope, $http, $location) {
    var self = this;
    var uriCreate = 'http://localhost:64014/Contacts/Create';

    self.create = function () {
        $http.post(uriCreate, self.contact).then(
            function () {
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


app.controller('messageController', function ($scope, $http, $location) {
    var self = this;
    var uri = 'http://localhost:64014/Contacts';
    $http.get(uri).then(function (response) { self.contacts = response.data; });

    var message = {};
    self.sendMsg = function (contactId) {
        self.message.ContactId = contactId;

        $http({
            method: 'POST',
            url: 'http://localhost:64014/Messages',
            data: self.message
        }).then(function () {
            $location.path("/");
        });
    };

    self.getEmail = function (contactId) {

        var result = false;
        angular.forEach(self.contacts, function (contact, key) {
            if (contactId === contact.Id)
                result = contact.Email;
        });
        return result;
    };

    self.getAllMsg = function () {
        $http({
            method: 'GET',
            url: 'http://localhost:64014/Messages'
        }).then(function (response) {
            self.messageList = response.data;
        });
    }

    self.remove = function (msg) {
        $http({
            method: 'DELETE',
            url: 'http://localhost:64014/Messages',
            params: { id: msg.Id }
        }).then(function () {
            $location.path("/message/all");
        });
    }
});


app.controller('loginController', function ($scope, $http) {
    var self = this;
    self.facebook = {
        usename: '',
        password: ''
    };
    self.OnFBLogin = function () {
        FB.login(function (response) {
            if (response.authResponse) {
                FB.api('/me', 'GET', { fields: 'email' }, function (response) {
                    self.$apply(function () {
                        $facebook.email = response.email;

                    });
                });
            }
        }, {
                scope: 'email',
                return_scopes: true
            });
    }

});

window.fbAsyncInit = function () {
    FB.init({
        appId: '1376825639104971',
        autoLogAppEvents: true,
        xfbml: true,
        version: 'v2.9',
        status: true
    });

    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            console.log('fb connected');
        } else if (response.status === 'not_authorized') {
            console.log('not authorized');
        }
    });
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));




app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/', { controller: 'contactsController', templateUrl: '/App/Templates/List.html' })
        .when('/create', { controller: 'contactCreateController', templateUrl: '/App/Templates/Create.html' })
        .when('/edit/:id', { controller: 'contactEditController', templateUrl: '/App/Templates/Edit.html' })
        .when('/message', { controller: 'messageController', templateUrl: '/App/Templates/Message.html' })
        .when('/message/all', { controller: 'messageController', templateUrl: '/App/Templates/MessageList.html' })
        .when('/login', { controller: 'loginController', templateUrl: '/App/Templates/Login.html' });


});

app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);


