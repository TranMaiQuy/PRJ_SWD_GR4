import React, { useEffect, useState } from "react";


const Blog = () => {
  const [blogs, setBlogs] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchBlogs();
  }, []);

  const fetchBlogs = () => {
    setLoading(true);
    fetch("https://localhost:7012/api/blog/list")
      .then((response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        return response.json();
      })
      .then((data) => {
        setBlogs(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching blogs:", error);
        setError("Could not fetch blogs.");
        setLoading(false);
      });
  };

  const handleDelete = async (id) => {
    if (!window.confirm("Are you sure you want to delete this blog?")) return;

    try {
      const response = await fetch(`https://localhost:7012/api/blog/${id}`, {
        method: "DELETE",
      });

      if (!response.ok) {
        throw new Error("Failed to delete blog");
      }

      // Refresh list
      fetchBlogs();
    } catch (error) {
      console.error("Delete error:", error);
      alert("Error deleting blog");
    }
  };

  const handleCreate = () => {
    // Điều hướng đến trang tạo mới
    window.location.href = "/blog/create";
  };

  const handleDetail = (id) => {
    window.location.href = `/blog/detail/${id}`;
  };

  const handleEdit = (id) => {
    window.location.href = `/blog/edit/${id}`;
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p style={{ color: "red" }}>{error}</p>;

  return (
    <div className="blog-container" style={{ padding: "20px" }}>
      <h2>Blog List</h2>
      <button onClick={handleCreate} style={{
        marginBottom: "20px",
        padding: "10px 15px",
        backgroundColor: "#28a745",
        color: "white",
        border: "none",
        borderRadius: "5px",
        cursor: "pointer"
      }}>
        + Create New Blog
      </button>

      {blogs.length === 0 ? (
        <p>No blogs found.</p>
      ) : (
        <div className="blog-list">
          {blogs.map((blog) => (
            <div key={blog.blogId} className="blog-card" style={{
              border: "1px solid #ccc",
              padding: "15px",
              borderRadius: "10px",
              marginBottom: "15px"
            }}>
              <h3>{blog.title}</h3>
              <p><strong>Description:</strong> {blog.description}</p>
              <img
                src={
                  blog.image.startsWith("https")
                    ? blog.image
                    : `https://localhost:7012/images/${blog.image}`
                }
                alt={blog.title}
                style={{ maxWidth: "100%", height: "auto", margin: "10px 0" }}
              />
              <p>{blog.content}</p>
              <p><strong>Created Date:</strong> {blog.createdDate}</p>
              <p><strong>Person Name:</strong> {blog.personName}</p>
              <p><strong>Category Name:</strong> {blog.categoryName}</p>

              {/* Action buttons */}
              <div style={{ marginTop: "10px" }}>
                <button 
                  onClick={() => handleDetail(blog.blogId)}
                  style={{ marginRight: "10px" }}
                >
                  Detail
                </button>
                <button
                  onClick={() => handleEdit(blog.blogId)}
                  style={{ marginRight: "10px" }}
                >
                  Edit
                </button>
                <button
                  onClick={() => handleDelete(blog.blogId)}
                  style={{ backgroundColor: "red", color: "white" }}
                >
                  Delete
                </button>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default Blog;
