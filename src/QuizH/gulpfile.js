﻿/// <binding AfterBuild='default' Clean='clean' ProjectOpened='move-types' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del');

var paths = {
    scripts: ['scripts/**/*.js', 'scripts/**/*.ts', 'scripts/**/*.map'],
    types:['node_modules/@types/**/*.d.ts']
};

gulp.task('move-types', function () {
    gulp.src(paths.types).pipe(gulp.dest('typings/modules'));
});

gulp.task('clean', function () {
    return del(['wwwroot/scripts/**/*']);
});

gulp.task('default', function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/js'));
    gulp.src(['node_modules/requirejs/require.js'])
        .pipe(gulp.dest('wwwroot/lib/requirejs'));
});