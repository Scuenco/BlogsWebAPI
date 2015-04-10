app.controller('HomeController', ['$scope', 'BlogFactory', 'LoginFactory', function ($scope, BlogFactory, LoginFactory) {
    $scope.status = LoginFactory.status,
    $scope.user = {},
    $scope.blogs = BlogFactory.blogs,

    $scope.login = function () {
        LoginFactory.login($scope.user).then(function () {
            $scope.user.username = $scope.user.password = '';
            BlogFactory.GetBlogs();
        })
    }
    $scope.logout = function () {
        LoginFactory.logout();
    }

    if ($scope.status.isLoggedIn) {
        BlogFactory.GetBlogs();
    }
}]);