// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    document.addEventListener('DOMContentLoaded', function() {
    const logo = document.getElementById('logo');

    function startAnimation() {

        setTimeout(() => {
            logo.classList.add('animate');
        }, 10);
   }
    startAnimation();
});
</script>