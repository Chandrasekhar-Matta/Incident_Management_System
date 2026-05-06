import { useEffect, useState } from "react";

export default function Detail() {
    const [item, setItem] = useState(null);

    const id = window.location.pathname.split("/")[2];

    useEffect(() => {
        fetch("https://localhost:44300/api/workitems")
            .then(res => res.json())
            .then(data => setItem(data.find(x => x.id == id)));
    }, [id]);

    if (!item) return <div>Loading...</div>;

    return (
        <div style={{ padding: 20 }}>
            <h2>Incident Detail</h2>

            <p>Component: {item.componentId}</p>
            <p>Status: {item.status}</p>

            <button onClick={() =>
                window.location.href = `/rca/${item.id}`
            }>
                Submit RCA
            </button>
        </div>
    );
}