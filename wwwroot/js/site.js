document.addEventListener("DOMContentLoaded", function () {
  // ==========================
  // --- Form Validation + Toast
  // ==========================
  const forms = document.querySelectorAll("form");

  forms.forEach((form) => {
    form.addEventListener("submit", function (e) {
      if (!form.checkValidity()) {
        e.preventDefault();
        e.stopPropagation();

        let messages = [];
        form.querySelectorAll(".input-validation-error").forEach((input) => {
          const label = document.querySelector(`label[for='${input.id}']`);
          const labelText = label ? label.textContent : input.name;
          messages.push(`${labelText} está incorreto ou obrigatório.`);
        });

        if (messages.length) {
          showToast(messages.join("<br>"), "warning");
        }
      }
      form.classList.add("was-validated");
    });
  });
});

// ==========================
// --- Global Toast Function
// ==========================
function showToast(message, type = "info") {
  let toastContainer = document.querySelector(".toast-container");
  if (!toastContainer) {
    toastContainer = document.createElement("div");
    toastContainer.className = "toast-container position-fixed top-0 end-0 p-3";
    toastContainer.style.zIndex = 1100;
    document.body.appendChild(toastContainer);
  }

  const toast = document.createElement("div");
  toast.className = `toast align-items-center text-bg-${type} border-0 show mb-2`;
  toast.setAttribute("role", "alert");

  toast.innerHTML = `
        <div class="d-flex">
            <div class="toast-body">${message}</div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
        </div>
    `;

  toastContainer.appendChild(toast);

  setTimeout(() => toast.remove(), 5000);
}
