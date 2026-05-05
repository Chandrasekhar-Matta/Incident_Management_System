import { useState } from "react";

export default function RCAForm() {
    const id = window.location.pathname.split("/")[2];

    const [rootCause, setRootCause] = useState("");
    const [fix, setFix] = useState("");
    const [prevention, setPrevention] = useState("");

    const submit = async () => {
        await fetch("https://localhost:44300/api/rca", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                workItemId: parseInt(id),
                rootCause,
                fix,
                prevention
            })
        });

        await fetch(`http://localhost:5001/api/workitems/${id}/close`, {
            method: "POST"
        });

        alert("Incident Closed ✅");
        window.location.href = "/";
    };

    return (
        <div style={{ padding: 20 }}>
            <h2>RCA Form</h2>

            <textarea
                placeholder="Root Cause"
                onChange={e => setRootCause(e.target.value)}
            /><br /><br />

            <textarea
                placeholder="Fix Applied"
                onChange={e => setFix(e.target.value)}
            /><br /><br />

            <textarea
                placeholder="Prevention Steps"
                onChange={e => setPrevention(e.target.value)}
            /><br /><br />

            <button onClick={submit}>Submit RCA</button>
        </div>
    );
}