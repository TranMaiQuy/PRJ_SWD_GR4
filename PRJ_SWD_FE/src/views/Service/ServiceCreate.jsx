import React, { useState } from "react";

const ServiceCreate = () => {
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

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm({
      ...form,
      [name]: name === "price" || name === "managerId" || name === "status" ? Number(value) : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    fetch("https://localhost:7012/api/service/create", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    })
      .then((res) => {
        if (!res.ok) throw new Error("Failed to create service");
        alert("Service created successfully!");
        window.location.href = "/service";
      })
      .catch((err) => {
        console.error("Create error:", err);
        alert("Error creating service");
      });
  };

  return (
    <div style={{ maxWidth: "600px", margin: "0 auto" }}>
      <h2>Create New Service</h2>
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
        <select name="image" value={form.image} onChange={handleChange} required>
          <option value="">-- Select image --</option>
          <option value="Annual Physicals for Kids-min.jpg">Annual Physicals</option>
          <option value="web-thumbnail-1-5x-100.jpg">Vaccination</option>
          <option value="iStock-636653206.jpg">Nutrition</option>
          <option value="private-versus-public-evaluations.jpg">Psychology</option>
          <option value="kids-dentistry-min-925x425.jpg">Dental Care</option>
          <option value="pediatric-care.jpg">Pediatric Care</option>
        </select>
        <br />
        {form.image && (
          <img
            src={`/images/${form.image}`}
            alt="Preview"
            style={{ width: "200px", marginTop: "10px" }}
          />
        )}


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

        <button type="submit">Create</button>{" "}
        <button type="button" onClick={() => window.location.href = "/service"}>Cancel</button>
      </form>
    </div>
  );
};

export default ServiceCreate;
