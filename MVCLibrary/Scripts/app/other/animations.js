
angular.module('MVCLibrary.animations', ['ngAnimate'])
      .animation('.repeated-item', function () {
          return {
              enter: function (element, done) {
                  element.css({
                      opacity: 0
                  });
                  $(element).animate({
                      opacity: 1
                  }, 850, done);

                  return function (isCancelled) {
                      if (isCancelled) {
                          jQuery(element).stop();
                      }
                  }

              },
              leave: function (element, done) {
                  element.css({
                      opacity: 1
                  });
                  $(element).animate({
                      opacity: 0
                  }, done);
              }
          };
      });