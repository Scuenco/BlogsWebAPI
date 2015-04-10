app.factory('BlogFactory', ['$http', '$q', function ($http, $q) {
    var blogs = [];

    var GetBlogs = function () {
        var deferred = $q.defer();
        $http({
            method: 'GET',
            url: '/api/apiBlog/', //routeTemplate: "api/{controller}/{id}"
            contentType: 'application/json',
            headers: { Authorization: "Bearer " + localStorage.getItem('token') }
        }).success(function (data) {
            blogs.length = 0; //empty contents
            for (var i = 0; i < data.length; i++) {
                blogs.push(data[i]); //populate blogs array
            }
            deferred.resolve(data);
        }).error(function (data) {
            deferred.reject(data);
        });
        return deferred.promise;
    }

    return {
        GetBlogs: GetBlogs,
        blogs: blogs
    }
}]);