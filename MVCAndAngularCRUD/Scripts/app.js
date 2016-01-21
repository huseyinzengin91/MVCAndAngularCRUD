var app = angular.module("myApp", []);

    
    app.controller("Controller", function ($scope, $http) {

        //Get Book List
        $http.get("/Home/GetBookList").success(function (data) {
            $scope.BookList = data;
        }).error(function (ex) {
            console.log(ex);
        });

        $scope.isRecordVisible = false;


        //Select all list
        $scope.SelectAll = function () {
            if ($scope.isSelectAll) {
                angular.forEach($scope.BookList, function (book) {
                    book.IsDeleted = true;
                    console.log(book);
                });
            }
            else {
                angular.forEach($scope.BookList, function (book) {
                    book.IsDeleted = false;
                });
            }
        }

        //Set new record form visible
        $scope.SetRecordVisible = function () {
            $scope.isRecordVisible = !$scope.isRecordVisible;
        }
        
        $scope.Save = function () {

            var newBook = { Name: this.name, Year: this.year};

            $http.post("/Home/NewBook", newBook).success(function (data) {
                $scope.lastID = data.ID;
                console.log("Kayıt Başarıyla Eklendi!")
            }).error(function (ex) {
                console.log(ex);
            });
        }

        //Delete Book
        $scope.DeleteBookList = function () {

            var deleteBooks = [];
            var list = [];

            angular.forEach($scope.BookList, function (book) {
                if (book.IsDeleted) {
                    deleteBooks.push(book.ID);
                } else {
                    list.push(book);
                }
            });
          

            if (deleteBooks != null && deleteBooks.length > 0) {
                $http.post("/Home/DeleteBooks", deleteBooks).success(function () {
                                console.log("Kayıtlar Başarı ile silindi!")
                            }).error(function (ex) {
                            console.log(ex);
                            });
            }

            $scope.BookList = [];
            angular.forEach(list, function (item) {
                $scope.BookList.push(item);
            });
        }

    });

    

