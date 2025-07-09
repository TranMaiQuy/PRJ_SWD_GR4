import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const ServiceEdit = () => {
  const { id } = useParams();
  const [form, setForm] = useState({
    serviceName: "",
    price: 0,
    description: "",
    image: "",
    duration: "",
    detail: "",
    managerId: 0,
    status: 1,
  });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7012/api/service/detail/${id}`)
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch service");
        return res.json();
      })
      .then((data) => {
        setForm(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Fetch error:", err);
        alert("Error loading service data");
        setLoading(false);
      });
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm({
      ...form,
      [name]: name === "price" || name === "managerId" || name === "status" ? Number(value) : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    fetch(`https://localhost:7012/api/service/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    })
      .then((res) => {
        if (!res.ok) throw new Error("Failed to update service");
        alert("Service updated successfully!");
        window.location.href = "/service";
      })
      .catch((err) => {
        console.error("Update error:", err);
        alert("Error updating service");
      });
  };

  if (loading) return <p>Loading...</p>;

  return (
    <div style={{ maxWidth: "600px", margin: "0 auto" }}>
      <h2>Edit Service #{id}</h2>
      <form onSubmit={handleSubmit}>
        <label>Service Name:</label>
        <input type="text" name="serviceName" value={form.serviceName} onChange={handleChange} required />
        <br />

        <label>Price:</label>
        <input type="number" name="price" value={form.price} onChange={handleChange} required />
        <br />

        <label>Description:</label>
        <textarea name="description" value={form.description} onChange={handleChange} required />
        <br />

        <label>Image:</label>
        <input type="text" name="image" value={form.image} onChange={handleChange} required />
        <br />

        <label>Duration:</label>
        <input type="text" name="duration" value={form.duration} onChange={handleChange} />
        <br />

        <label>Detail:</label>
        <textarea name="detail" value={form.detail} onChange={handleChange} />
        <br />

        <label>Manager ID:</label>
        <input type="number" name="managerId" value={form.managerId} onChange={handleChange} required />
        <br />

        <label>Status:</label>
        <select name="status" value={form.status} onChange={handleChange}>
          <option value={1}>Active</option>
          <option value={0}>Inactive</option>
        </select>
        <br /><br />

        <button type="submit">Update</button>{" "}
        <button type="button" onClick={() => window.location.href = "/service"}>Cancel</button>
      </form>
    </div>
  );
};

export default ServiceEdit;
