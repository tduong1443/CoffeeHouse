// Hero-slider
$(".hero-slider2").owlCarousel({
    loop: true,
    nav: true,
    dots: false,
    margin: -1,
    autoplay: true,
    autoplayHoverPause: true,
    autoplayTimeout: 5000,
    items: 1,
    navText: [
        "<i class='fa-sharp fa-solid fa-arrow-left'></i>",
        "<i class='fa-sharp fa-solid fa-arrow-right'></i>",
    ],
});
$(".hero-slider2").on("change.owl.carousel", function (event) {
    new WOW().init();
});

// Why choose
$(".popup-youtube, .popup-vimeo, .popup-gmaps").magnificPopup({
    type: "iframe",
    mainClass: "mfp-fade",
    removalDelay: 160,
    preloader: false,
    fixedContentPos: false,
});

// Gallery
$(".gallery-slider").owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    navText: [
        "<i class='fa-sharp fa-solid fa-arrow-left'></i>",
        "<i class='fa-sharp fa-solid fa-arrow-right'></i>",
    ],
    dots: false,
    autoplay: true,
    responsive: {
        0: { items: 1 },
        600: { items: 2 },
        1000: { items: 3 },
    },
});

$(".popup-gallery").magnificPopup({
    delegate: ".popup-img",
    type: "image",
    gallery: { enabled: true },
});

// Offer
$(".offer-slider").owlCarousel({
    loop: true,
    margin: 30,
    animateOut: "fadeOut",
    navText: [
        "<i class='far fa-long-arrow-left'></i>",
        "<i class='far fa-long-arrow-right'></i>",
    ],
    dots: true,
    autoplay: true,
    responsive: {
        0: { items: 1 },
        600: { items: 1 },
        1000: { items: 1 },
    },
});

// Counter
$.fn.countTo = function (options) {
    return this.each(function () {
        //-- Arrange
        var FRAME_RATE = 60;
        var $el = $(this);
        var countFrom = parseInt($el.attr("data-count-from"));
        var countTo = parseInt($el.attr("data-count-to"));
        var countSpeed = $el.attr("data-count-speed");

        //-- Action
        var rafId;
        var increment;
        var currentCount = countFrom;
        var countAction = function () {
            if (currentCount < countTo) {
                $el.text(Math.floor(currentCount));
                increment = countSpeed / FRAME_RATE;
                currentCount += increment;
                rafId = requestAnimationFrame(countAction);
            } else {
                $el.text(countTo);
                cancelAnimationFrame(rafId);
            }
        };
        rafId = requestAnimationFrame(countAction);
    });
};
$(".counter").countTo();

// Partner
$(".partner-slider").owlCarousel({
    loop: true,
    margin: 20,
    nav: false,
    dots: false,
    autoplay: true,
    responsive: {
        0: { items: 2 },
        600: { items: 3 },
        1000: { items: 6 },
    },
});

// Scroll
$(window).scroll(function () {
    if (
        document.body.scrollTop > 100 ||
        document.documentElement.scrollTop > 100
    ) {
        $("#scroll-top").fadeIn("slow");
    } else {
        $("#scroll-top").fadeOut("slow");
    }
});

$("#scroll-top").click(function () {
    $("html, body").animate({ scrollTop: 0 }, 1000);
    return false;
});

$(window).scroll(function () {
    if ($(this).scrollTop() > 50) {
        $(".navbar").addClass("fixed-top");
    } else {
        $(".navbar").removeClass("fixed-top");
    }
});

//  Shop
(function ($) {
    if ($(".price-range").length) {
        $(".price-range").slider({
            range: true,
            min: 0,
            max: 999,
            values: [100, 500],
            slide: function (event, ui) {
                $("#price-amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
            },
        });
        $("#price-amount").val(
            "$" +
            $(".price-range").slider("values", 0) +
            " - $" +
            $(".price-range").slider("values", 1)
        );
    }
})(jQuery);

// Shop Cart
$(".plus-btn").on("click", function () {
    var i = $(this).closest(".cart-quantity").children(".quantity").get(0)
        .value++,
        c = $(this).closest(".cart-quantity").children(".minus-btn");
    i > 0 && c.removeAttr("disabled");
}),
    $(".minus-btn").on("click", function () {
        2 ==
            $(this).closest(".cart-quantity").children(".quantity").get(0).value-- &&
            $(this).attr("disabled", "disabled");
    });

// Shop Single
if ($(".flexslider-thumbnails").length) {
    $(".flexslider-thumbnails").flexslider({
        animation: "slide",
        controlNav: "thumbnails",
    });
}

// Sign in
const loginForm = document.getElementById("login-form");
const userField = document.querySelector('input[name="user"]');
const passwordField = document.querySelector('input[name="password"]');
const submitButton = document.getElementById("submit-button");
const userError = document.getElementById("user-error");
const passwordError = document.getElementById("password-error");
const successMessage = document.getElementById("success-message");

// Xử lý sự kiện khi người dùng ấn nút "Sign in"
submitButton.addEventListener("click", function (e) {
    e.preventDefault(); // Ngăn form submit

    // Kiểm tra xem trường "Username" và "Password" có rỗng hay không
    if (userField.value.trim() === "") {
        userError.innerText = "Enter for Username or email address.";
        userError.style.color = "red";
    } else {
        userError.innerText = ""; // Xóa thông báo lỗi
    }

    if (passwordField.value.trim() === "") {
        passwordError.innerText = "Enter your Password.";
        passwordError.style.color = "red";
    } else {
        passwordError.innerText = ""; // Xóa thông báo lỗi
    }

    if (userField.value.trim() !== "" && passwordField.value.trim() !== "") {
        // Nếu cả hai trường không trống, hiển thị thông báo thành công và lưu dữ liệu vào Google
        successMessage.style.display = "block";
        // Thực hiện lưu dữ liệu vào Google ở đây
    }
});

// Join now
document.addEventListener("DOMContentLoaded", function () {
    const passwordInput = document.getElementById("password");
    const togglePassword = document.getElementById("toggle-password");
    const passwordValidation = document.getElementById("password-validation");
    const submitButton = document.getElementById("submit-button");

    const firstField = document.querySelector('input[name="firstname"]');
    const firstError = document.getElementById("first-error");
    const lastField = document.querySelector('input[name="lastname"]');
    const lastError = document.getElementById("last-error");
    const emailField = document.querySelector('input[name="email"]');
    const emailError = document.getElementById("email-error");

    togglePassword.addEventListener("click", function () {
        if (passwordInput.type === "password") {
            passwordInput.type = "text";
            togglePassword.classList.remove("fa-eye-slash");
            togglePassword.classList.add("fa-eye");
        } else {
            passwordInput.type = "password";
            togglePassword.classList.remove("fa-eye");
            togglePassword.classList.add("fa-eye-slash");
        }
    });

    submitButton.addEventListener("click", function (event) {
        passwordValidation.innerHTML = "";

        if (passwordInput.value.length < 8 || passwordInput.value.length > 25) {
            passwordValidation.innerHTML += "<li>From 8 to 25 characters</li>";
        }

        if (!/[0-9]/.test(passwordInput.value)) {
            passwordValidation.innerHTML +=
                "<li>Not satisfied: At least one number</li>";
        }

        if (!/[A-Z]/.test(passwordInput.value)) {
            passwordValidation.innerHTML +=
                "<li>Not satisfied: At least one capital letter</li>";
        }

        if (!/[a-z]/.test(passwordInput.value)) {
            passwordValidation.innerHTML +=
                "<li>Satisfied: At least one lowercase letter</li>";
        }

        if (!/[!@#$%^&*]/.test(passwordInput.value)) {
            passwordValidation.innerHTML +=
                "<li>Not satisfied: At least one special character</li>";
        }

        if (passwordValidation.innerHTML !== "") {
            event.preventDefault(); // Prevent form submission
        }

        if (passwordValidation.innerHTML !== "" || errorMessages.innerHTML !== "") {
            event.preventDefault(); // Prevent form submission
        }
    });

    submitButton.addEventListener("click", function (e) {
        e.preventDefault(); // Ngăn form submit

        // Kiểm tra xem trường "Username" và "Password" có rỗng hay không
        if (firstField.value.trim() === "") {
            firstError.innerText = "Enter your first name.";
            firstError.style.color = "red";
        } else {
            firstError.innerText = ""; // Xóa thông báo lỗi
        }

        if (lastField.value.trim() === "") {
            lastError.innerText = "Enter your last name.";
            lastError.style.color = "red";
        } else {
            lastError.innerText = ""; // Xóa thông báo lỗi
        }

        if (emailField.value.trim() === "") {
            emailError.innerText = "Enter your email.";
            emailError.style.color = "red";
        } else {
            emailError.innerText = ""; // Xóa thông báo lỗi
        }
    });
});
