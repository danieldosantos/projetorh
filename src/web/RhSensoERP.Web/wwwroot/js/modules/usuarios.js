(function () {
    const table = new DataTable('#usuariosTable', {
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.13.8/i18n/pt-BR.json'
        }
    });

    const modalElement = document.getElementById('modalUsuario');
    const modal = new bootstrap.Modal(modalElement);

    document.getElementById('btnNovoUsuario')?.addEventListener('click', function () {
        modal.show();
    });

    document.getElementById('btnSalvarUsuario')?.addEventListener('click', function () {
        const form = document.getElementById('formUsuario');
        if (!form) return;

        const formData = new FormData(form);
        const payload = {
            nome: formData.get('Nome'),
            email: formData.get('Email'),
            ativo: formData.get('Ativo') === 'true',
            permissoes: String(formData.get('Permissoes') || '').split(',').map(p => p.trim()).filter(Boolean)
        };

        fetch('/SEG/Usuarios', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        }).then(() => {
            Swal.fire({
                icon: 'success',
                title: 'Usuário cadastrado!',
                showConfirmButton: false,
                timer: 1500
            });
            modal.hide();
        }).catch(() => {
            Swal.fire({
                icon: 'error',
                title: 'Erro ao salvar usuário'
            });
        });
    });
})();
