document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('searchForm');
    const results = document.getElementById('searchResults');

    if (!form || !results) return;

    const canEdit = results.dataset.canEdit === 'true';
    const detailsUrl = results.dataset.detailsUrl;
    const editUrl = results.dataset.editUrl;

    function escapeHtml(text) {
        const div = document.createElement('div');
        div.textContent = text ?? '';
        return div.innerHTML;
    }

    function showMessage(text, cssClass) {
        results.innerHTML = `<div class="col-12"><p class="${cssClass}">${escapeHtml(text)}</p></div>`;
    }

    function renderCard(shop) {
        const id = encodeURIComponent(shop.id);

        const editButton = canEdit
            ? `<a href="${editUrl}/${id}" class="btn btn-outline-secondary px-3">Edit</a>`
            : '';

        return `
            <div class="col">
                <div class="card h-100 position-relative">
                    <div class="card-body d-flex flex-column p-4">
                        <h5 class="card-title mb-4" style="font-size: 1.15rem;">${escapeHtml(shop.name)}</h5>
                        <div class="d-flex gap-2 mt-auto pt-2">
                            <a href="${detailsUrl}/${id}" class="btn btn-outline-primary flex-fill">More information</a>
                            ${editButton}
                        </div>
                    </div>
                </div>
            </div>`;
    }

    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        const nameInput = document.getElementById('Name');
        const name = nameInput ? nameInput.value.trim() : '';

        try {
            const response = await fetch(`${form.action}?Name=${encodeURIComponent(name)}`);

            if (response.status === 404) {
                showMessage('No stores found.', 'text-muted');
                return;
            }
            if (!response.ok) {
                showMessage('Search failed.', 'text-danger');
                return;
            }

            const data = await response.json();
            const shops = Array.isArray(data) ? data : (data ? [data] : []);

            if (shops.length === 0) {
                showMessage('No stores found.', 'text-muted');
                return;
            }

            results.innerHTML = shops.map(renderCard).join('');
        } catch {
            showMessage('Search failed.', 'text-danger');
        }
    });
});