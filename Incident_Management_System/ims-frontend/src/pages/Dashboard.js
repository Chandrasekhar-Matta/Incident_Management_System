import { useEffect, useState } from "react";

export default function Dashboard() {
    const [data, setData] = useState([]);

    useEffect(() => {
        fetch(`${process.env.REACT_APP_API}/api/workitems`)
            .then(res => {
                if (!res.ok) throw new Error("API failed");
                return res.json();
            })
            .then(setData)
            .catch(err => console.error("API ERROR:", err));
    }, []);

    return (
        <div style={{ padding: 20 }}>
            <h2>🚨 Active Incidents</h2>

            {data.map(x => (
                <div key={x.id} style={{
                    border: "1px solid gray",
                    margin: 10,
                    padding: 10
                }}>
                    <h3>{x.componentId}</h3>
                    <p>Status: {x.status}</p>
                    <p>Severity: {x.severity}</p>

                    <button onClick={() =>
                        window.location.href = `/detail/${x.id}`
                    }>
                        View Details
                    </button>
                </div>
            ))}
        </div>
    );
}