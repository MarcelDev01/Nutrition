﻿const hamburger = document.querySelector(".toggle-btn");
const toggler = document.querySelector("#icon");

hamburger.addEventListener("click", function()
{
    document.querySelector("#sidebar").classList.toggle("expand");

    toggler.classList.toggle("bxs-chevron-right");
    toggler.classList.toggle("bxs-chevron-left");
});