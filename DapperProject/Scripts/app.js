var app = angular.module('plunker', []);

app.controller('MainCtrl', function ($scope) {
    $scope.name = 'World';

    $scope.items = [{
        "src": "http://t3.gstatic.com/images?q=tbn:ANd9GcR1Kp2JmcnxhBOf66aN_JqMWl3h_okOQKFX_kEqwr9mRe5iPomy",
        "alt": "image 001"
    }, {
        "src": "http://t3.gstatic.com/images?q=tbn:ANd9GcQAoT9UmjmunwFTAA19_n1auOFR_JG017_TUru-E91T7nIH8HyU",
        "alt": "image 002"
    }, {
        "src": "http://t2.gstatic.com/images?q=tbn:ANd9GcTfntbVv3pl5wFCe6IdkaMVrme_Au9TD8Z_xE95Ezv6jz8oK4nT",
        "alt": "image 003"
    }, {
        "src": "http://t1.gstatic.com/images?q=tbn:ANd9GcSAOralDJGSVtfirbHG5VdFqG8fTqXMh7C4Xd_aHCy176SKNQqK",
        "alt": "image 004"
    }, {
        "src": "http//fc08.deviantart.net/fs70/f/2012/122/0/c/landscape_wallpaper_by_nickchoubg-d4yaep3.png",
        "alt": "image 005"
    }, ];

    $scope.ZoomItems = [];
    $scope.ZoomItems.push({
        id: 0,
        big: "http://www.professorcloud.com/images/zoomengine/bigimage00.jpg",
        tiny: "http://www.professorcloud.com/images/zoomengine/tinyimage.jpg",
        small: "http://www.professorcloud.com/images/zoomengine/smallimage.jpg",
        title: "display title",
    });
    $scope.ZoomItems.push({
        id: 1,
        big: "http://www.professorcloud.com/images/zoomengine/bigimage01.jpg",
        tiny: "http://www.professorcloud.com/images/zoomengine/tinyimage-1.jpg",
        small: "http://www.professorcloud.com/images/zoomengine/smallimage-1.jpg",
        title: "display title",
    });
    $scope.ZoomItems.push({
        id: 2,
        big: "http://www.professorcloud.com/images/zoomengine/bigimage02.jpg",
        tiny: "http://www.professorcloud.com/images/zoomengine/tinyimage-2.jpg",
        small: "http://www.professorcloud.com/images/zoomengine/smallimage-2.jpg",
        title: "display title",
    });

    $scope.SelectedItem = $scope.ZoomItems[0];

    $scope.ThumbnailClicked = function (Item) {
        $scope.SelectedItem = Item;

    };


});

app.directive('thumbnail', [

  function () {
      return {
          restrict: 'AC',
          link: function (scope, elem, attrs) {
              elem.bind('click', function () {
                  var src = elem.find('img').attr('src');

                  // call your SmoothZoom here
                  angular.element(attrs.options).css({
                      'background-image': 'url(' + src + ')'
                  });
              });
          }
      };
  }
]);



app.directive('zoom', [

  function () {
      return {
          restrict: 'AC',
          scope: {
              //  tiny: "=",
              // small: "=",
              //  big: "=",
              //  title: "=",
          },
          link: function (scope, elem, attrs) {
              //elem.bind('click', function() {
              //  $(this).CloudZoom();
              //});

              //     var options = {}; // This would be your options object.
              //elem.CloudZoom(options);                  // jQuery way.
              //myInstance = new CloudZoom(elem ,options); // 'normal' way.



              //   var str = '<div id="wrap" style="top:0px;z-index:9999;position:relative;">' +
              //    '<a href="' + scope.big + '" class="cloud-zoom" id="zoom1" rel="adjustX: 10, adjustY:-4, softFocus:true" style="position: relative; display: block;">' +
              //    '<img src="' + scope.small + '" alt="" align="left" title="' + title + '" style="display: block;">' +
              //    '<div style="position: absolute; top: 2px; left: 2px; width: 238px; height: 318px; background-image: url(' + small + '); opacity: 0.5; display: none; background-position: initial initial; background-repeat: initial initial;"></div></a><div class="mousetrap" style="background-image: url(http://www.professorcloud.com/mainsite/); z-index: 999; position: absolute; width: 240px; height: 320px; left: 0px; top: 0px; cursor: move;"></div></div>';



              //var $this = $(this);
              //   var src = elem.attr('src');
              var str = '<a href="' + attrs.tiny + '" class="cloud-zoom" rel="adjustX: 10, adjustY:-4" />';
              elem.wrap(str);
              $(".cloud-zoom, .cloud-zoom-gallery").CloudZoom();


          }
      };
  }
]);


app.directive('zoom1',
  function ($compile) {
      return {
          restrict: 'AC',
          scope: {
              title: "=",
              tiny: "=",
              small: "=",
              big: "="
          },
          //Template doesn't seem work correctly, leaves a loading message.
          //template: '<a href="{{big}}" class="cloud-zoom" rel="adjustX: 10, adjustY:-4"><img src="{{small}}"/></a>',
          //replace: true,
          link: function (scope, element, attrs) {


              var str = '<a href="' + scope.big + '" class="cloud-zoom" rel="adjustX: 10, adjustY:-4">' +
                '<img src="' + scope.small + '"/></a>';
              var e = $compile(str)(scope);
              element.replaceWith(e);

              $(".cloud-zoom, .cloud-zoom-gallery").CloudZoom();
          }
      };
  }
);



app.directive('zoom2', ['$compile',
  function ($compile) {
      return {
          restrict: 'AC',
          scope: {
              tiny: "=",
              small: "=",
              big: "=",
              title: "="
          },
          //Template doesn't seem work correctly, leaves a loading message.
          //template: '<a href="{{big}}" class="cloud-zoom" rel="adjustX: 10, adjustY:-4"><img src="{{small}}"/></a>',
          //replace: true,
          controller: ["$scope", "$attrs", "$element", "$compile",
            function ($scope, $attrs, $element, $compile) {

                $scope.init = function () {



                    //Create a watch to know when to open the PopOver Text
                    $scope.$watch('tiny + small + big + title', function (newValue, oldValue) {
                        console.log("in watch.");


                        var str = $scope.small + ' <a href="' + $scope.big + '" class="cloud-zoom" rel="adjustX: 10, adjustY:-4">' +
                          '<img src="' + $scope.small + '"/></a>';
                        var e = $compile(str)($scope);

                        $element.html(e);

                        $(".cloud-zoom, .cloud-zoom-gallery").CloudZoom();

                    }, true);

                }; // end init

                //set the popover properties
                $scope.init();

            }
          ]

      };
  }
]);