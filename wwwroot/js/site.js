// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let navigation_bar = document.querySelector(".navbar2");
let menus_btn = document.querySelector(".menu-btn");
let close_btn = document.querySelector(".close-btn");

menus_btn.addEventListener("click", function () {
    console.log("Menu icon clicked");
    navigation_bar.classList.add("menu-active");

});

close_btn.addEventListener("click", function () {
    navigation_bar.classList.remove("menu-active");
});