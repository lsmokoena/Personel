/// <binding BeforeBuild='clean' AfterBuild='default, all, copy' Clean='clean' />
/*module.exports = function (grunt) {
    grunt.initConfig({
        clean: {
                    options: {
                        'no-write': true
                    },
                    all: ["wwwroot/css/", "wwwroot/js/"]
               },
        copy: {
            main: {
                files: [
                    {
                        src: "node_modules/bootstrap/dist/fonts/*",
                        dest: "wwwroot/fonts/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    {
                        src: "node_modules/bootstrap/dist/css/*",
                        dest: "wwwroot/css/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    {
                        src: "node_modules/bootstrap/dist/js/*",
                        dest: "wwwroot/js/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    {
                        src: "node_modules/jquery/dist/*",
                        dest: "wwwroot/js",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    }
                ]
            }
        }
    });
    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.registerTask("all", ["clean", "copy"]);
    grunt.registerTask("default", "all");
};*/